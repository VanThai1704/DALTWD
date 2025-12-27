using System;
using System.Linq;
using System.Windows.Forms;
using QLNhaSach.Models;
using QLNhaSach.Tools;

namespace QLNhaSach
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Kiểm tra và migrate users sang hệ thống mới với salt
            EnsurePasswordSaltMigration();
            
            // Optionally seed sample data by passing --seed as command line argument
            try
            {
                QLNhaSach.Tools.DatabaseSeeder.SeedSampleDataIfArg(args);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Seeding failed: " + ex);
            }

            NguoiDung user = null;
            using (var login = new FormDangNhap())
            {
                if (login.ShowDialog() != DialogResult.OK || login.DangNhapThanhCong == null)
                    return;
                user = login.DangNhapThanhCong;
            }
            Application.Run(new Form1(user));
        }

        /// <summary>
        /// Migrate tất cả users sang hệ thống mới với PasswordSalt
        /// </summary>
        static void EnsurePasswordSaltMigration()
        {
            try
            {
                using var db = new QLNhaSach.Models.QuanLyNhaSachContext();
                
                // Kiểm tra xem có user nào không
                var allUsers = db.NguoiDungs.ToList();
                
                if (!allUsers.Any())
                {
                    // Không có user nào - tạo admin mặc định
                    var adminRole = db.Roles.FirstOrDefault(r => r.RoleName == "Admin");
                    if (adminRole == null)
                    {
                        System.Windows.Forms.MessageBox.Show(
                            "Không tìm thấy Role Admin!\nVui lòng chạy CreateUserTables.sql",
                            "Lỗi",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Error);
                        Environment.Exit(1);
                        return;
                    }

                    // Tạo admin user
                    string salt;
                    string passwordHash = PasswordHelper.HashPasswordWithNewSalt("admin123", out salt);

                    var adminUser = new NguoiDung
                    {
                        TenDangNhap = "admin",
                        MatKhauHash = passwordHash,
                        PasswordSalt = salt,
                        HoTen = "Quản trị viên",
                        RoleId = adminRole.RoleId,
                        KichHoat = true
                    };
                    db.NguoiDungs.Add(adminUser);
                    db.SaveChanges();

                    System.Windows.Forms.MessageBox.Show(
                        "Đã tạo tài khoản admin mặc định:\n\n" +
                        "Tên đăng nhập: admin\n" +
                        "Mật khẩu: admin123\n\n" +
                        "Vui lòng đổi mật khẩu sau khi đăng nhập!",
                        "Khởi tạo hệ thống",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Information);
                    return;
                }
                
                // Kiểm tra users chưa có PasswordSalt
                var usersWithoutSalt = allUsers
                    .Where(u => string.IsNullOrEmpty(u.PasswordSalt))
                    .ToList();
                
                if (usersWithoutSalt.Any())
                {
                    var result = System.Windows.Forms.MessageBox.Show(
                        $"Phát hiện {usersWithoutSalt.Count} tài khoản chưa có mã bảo mật.\n\n" +
                        "Hệ thống cần cập nhật bảo mật cho các tài khoản này.\n" +
                        "Mật khẩu sẽ được đặt = tên đăng nhập.\n\n" +
                        "Tiếp tục?",
                        "Cập nhật bảo mật",
                        System.Windows.Forms.MessageBoxButtons.YesNo,
                        System.Windows.Forms.MessageBoxIcon.Warning);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        foreach (var user in usersWithoutSalt)
                        {
                            string salt;
                            string passwordHash = PasswordHelper.HashPasswordWithNewSalt(user.TenDangNhap, out salt);
                            user.PasswordSalt = salt;
                            user.MatKhauHash = passwordHash;
                        }
                        db.SaveChanges();
                        
                        System.Windows.Forms.MessageBox.Show(
                            $"Đã cập nhật {usersWithoutSalt.Count} tài khoản.\n\n" +
                            "Mật khẩu = tên đăng nhập\n" +
                            "Hãy đổi mật khẩu sau khi đăng nhập!",
                            "Hoàn tất",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Information);
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Lỗi khi kiểm tra bảo mật:\n{ex.Message}",
                    "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}
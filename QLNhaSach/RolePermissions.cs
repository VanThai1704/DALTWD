using System;

namespace QLNhaSach
{
    /// <summary>
    /// Quản lý phân quyền cho các roles trong hệ thống
    /// </summary>
    public static class RolePermissions
    {
        // Role IDs
        public const int ADMIN_ROLE_ID = 1;
        public const int NHANVIEN_ROLE_ID = 2;
        public const int QUANLY_ROLE_ID = 3;
        public const int READONLY_ROLE_ID = 4; // Nhân viên bán hàng - Chỉ xem

        // Role Names
        public const string ADMIN = "Admin";
        public const string NHANVIEN = "Nhân viên";
        public const string QUANLY = "Quản lý";
        public const string READONLY = "Nhân viên bán hàng";

        /// <summary>
        /// Kiểm tra user có phải Admin không
        /// </summary>
        public static bool IsAdmin(NguoiDung user)
        {
            if (user == null) return false;
            return user.RoleId == ADMIN_ROLE_ID || 
                   user.Role?.RoleName?.ToLower() == "admin";
        }

        /// <summary>
        /// Kiểm tra user có phải Quản lý không
        /// </summary>
        public static bool IsQuanLy(NguoiDung user)
        {
            if (user == null) return false;
            return user.RoleId == QUANLY_ROLE_ID;
        }

        /// <summary>
        /// Kiểm tra user có phải Nhân viên không
        /// </summary>
        public static bool IsNhanVien(NguoiDung user)
        {
            if (user == null) return false;
            return user.RoleId == NHANVIEN_ROLE_ID;
        }

        /// <summary>
        /// Kiểm tra user có phải ReadOnly (chỉ xem) không
        /// </summary>
        public static bool IsReadOnly(NguoiDung user)
        {
            if (user == null) return false;
            return user.RoleId == READONLY_ROLE_ID;
        }

        /// <summary>
        /// Kiểm tra user có quyền xem thống kê doanh thu không
        /// </summary>
        public static bool CanViewRevenue(NguoiDung user)
        {
            return IsAdmin(user) || IsQuanLy(user);
        }

        /// <summary>
        /// Kiểm tra user có quyền xuất Excel không
        /// </summary>
        public static bool CanExportExcel(NguoiDung user)
        {
            return IsAdmin(user) || IsQuanLy(user);
        }

        /// <summary>
        /// Kiểm tra user có quyền quản lý người dùng không
        /// </summary>
        public static bool CanManageUsers(NguoiDung user)
        {
            return IsAdmin(user);
        }

        /// <summary>
        /// Kiểm tra user có quyền sao lưu/phục hồi dữ liệu không
        /// </summary>
        public static bool CanBackupRestore(NguoiDung user)
        {
            return IsAdmin(user);
        }

        /// <summary>
        /// Kiểm tra user có quyền cấu hình hệ thống không
        /// </summary>
        public static bool CanConfigureSystem(NguoiDung user)
        {
            return IsAdmin(user);
        }

        /// <summary>
        /// Kiểm tra user có quyền xem nhật ký hoạt động không
        /// </summary>
        public static bool CanViewActivityLog(NguoiDung user)
        {
            return IsAdmin(user);
        }

        /// <summary>
        /// Kiểm tra user có quyền quản lý nhập xuất kho không
        /// </summary>
        public static bool CanManageInventory(NguoiDung user)
        {
            // Tất cả các role trừ ReadOnly có quyền nhập xuất kho
            return !IsReadOnly(user);
        }

        // ========== QUYỀN THÊM/SỬA/XÓA ==========

        /// <summary>
        /// Kiểm tra user có quyền THÊM sách không
        /// </summary>
        public static bool CanAddBook(NguoiDung user)
        {
            // ReadOnly không được thêm
            return !IsReadOnly(user);
        }

        /// <summary>
        /// Kiểm tra user có quyền SỬA sách không
        /// </summary>
        public static bool CanEditBook(NguoiDung user)
        {
            // ReadOnly không được sửa
            return !IsReadOnly(user);
        }

        /// <summary>
        /// Kiểm tra user có quyền XÓA sách không
        /// </summary>
        public static bool CanDeleteBook(NguoiDung user)
        {
            // Chỉ Admin và Quản lý
            return IsAdmin(user) || IsQuanLy(user);
        }

        /// <summary>
        /// Kiểm tra user có quyền THÊM khách hàng không
        /// </summary>
        public static bool CanAddCustomer(NguoiDung user)
        {
            return !IsReadOnly(user);
        }

        /// <summary>
        /// Kiểm tra user có quyền SỬA khách hàng không
        /// </summary>
        public static bool CanEditCustomer(NguoiDung user)
        {
            return !IsReadOnly(user);
        }

        /// <summary>
        /// Kiểm tra user có quyền XÓA khách hàng không
        /// </summary>
        public static bool CanDeleteCustomer(NguoiDung user)
        {
            return IsAdmin(user) || IsQuanLy(user);
        }

        /// <summary>
        /// Kiểm tra user có quyền THÊM đơn hàng không
        /// </summary>
        public static bool CanAddOrder(NguoiDung user)
        {
            return !IsReadOnly(user);
        }

        /// <summary>
        /// Kiểm tra user có quyền SỬA đơn hàng không
        /// </summary>
        public static bool CanEditOrder(NguoiDung user)
        {
            return !IsReadOnly(user);
        }

        /// <summary>
        /// Kiểm tra user có quyền XÓA đơn hàng không
        /// </summary>
        public static bool CanDeleteOrder(NguoiDung user)
        {
            return IsAdmin(user) || IsQuanLy(user);
        }

        /// <summary>
        /// Lấy tên vai trò theo ID
        /// </summary>
        public static string GetRoleName(int roleId)
        {
            return roleId switch
            {
                ADMIN_ROLE_ID => ADMIN,
                NHANVIEN_ROLE_ID => NHANVIEN,
                QUANLY_ROLE_ID => QUANLY,
                READONLY_ROLE_ID => READONLY,
                _ => "Unknown"
            };
        }

        /// <summary>
        /// Lấy mô tả quyền hạn của role
        /// </summary>
        public static string GetRoleDescription(int roleId)
        {
            return roleId switch
            {
                ADMIN_ROLE_ID => "Toàn quyền quản trị hệ thống",
                NHANVIEN_ROLE_ID => "Xem và thêm mới dữ liệu cơ bản",
                QUANLY_ROLE_ID => "Quản lý đầy đủ dữ liệu nghiệp vụ, xem báo cáo",
                READONLY_ROLE_ID => "Chỉ xem danh sách, không được thay đổi",
                _ => "Không xác định"
            };
        }
    }
}


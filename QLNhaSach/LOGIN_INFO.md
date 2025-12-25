# Thông tin ??ng nh?p h? th?ng

## Tài kho?n m?c ??nh

### Tài kho?n Admin
- **Tên ??ng nh?p:** admin
- **M?t kh?u:** admin123
- **Vai trò:** Qu?n tr? viên
- **Tr?ng thái:** ?ã kích ho?t

### Tài kho?n Nhân viên
- **Tên ??ng nh?p:** nhanvien1
- **M?t kh?u:** nv123
- **Vai trò:** Nhân viên
- **Tr?ng thái:** ?ã kích ho?t

## H??ng d?n thi?t l?p database

N?u b?n ch?a t?o b?ng `NguoiDung` và `Role`, vui lòng ch?y script SQL sau:

```bash
sqlcmd -S . -d QuanLyNhaSach -E -i CreateUserTables.sql
```

Ho?c m? file `CreateUserTables.sql` và ch?y trong SQL Server Management Studio.

## L?u ý b?o m?t

- M?t kh?u ???c mã hóa b?ng thu?t toán SHA256
- Hãy ??i m?t kh?u m?c ??nh sau khi ??ng nh?p l?n ??u
- Không chia s? thông tin ??ng nh?p v?i ng??i không có th?m quy?n

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySolution.DataLayers;   // Tham chiếu đến tầng Data Access
using MySolution.DomainModels; // Tham chiếu đến tầng Model

namespace MySolution.BusinessLayers
{
    public static class HRMService
    {
        // Biến static để giữ đối tượng DAL sau khi Initialize
        private static EmployeeDAL _employeeDAL;

        /// <summary>
        /// Hàm khởi tạo dịch vụ, cần được gọi 1 lần khi ứng dụng bắt đầu (ví dụ trong Program.cs)
        /// </summary>
        /// <param name="connectionString">Chuỗi kết nối đến CSDL</param>
        public static void Initialize(string connectionString)
        {
            _employeeDAL = new EmployeeDAL(connectionString);
        }

        // Helper để kiểm tra xem Service đã được Initialize chưa
        private static void CheckInitialization()
        {
            if (_employeeDAL == null)
            {
                throw new InvalidOperationException("HRMService chưa được khởi tạo. Vui lòng gọi HRMService.Initialize(connectionString) trước.");
            }
        }

        /// <summary>
        /// Lấy danh sách toàn bộ nhân viên
        /// </summary>
        public static async Task<List<Employee>> ListEmployeesAsync()
        {
            CheckInitialization();
            return await _employeeDAL.ListAsync();
        }

        /// <summary>
        /// Lấy thông tin chi tiết 1 nhân viên theo mã
        /// </summary>
        public static async Task<Employee> GetEmployeeAsync(string id)
        {
            CheckInitialization();
            return await _employeeDAL.GetAsync(id);
        }

        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        public static async Task<bool> AddEmployeeAsync(Employee data)
        {
            CheckInitialization();
            return await _employeeDAL.AddAsync(data);
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        public static async Task<bool> UpdateEmployeeAsync(Employee data)
        {
            CheckInitialization();
            return await _employeeDAL.UpdateAsync(data);
        }

        /// <summary>
        /// Xóa nhân viên theo mã
        /// </summary>
        public static async Task<bool> DeleteEmployeeAsync(string id)
        {
            CheckInitialization();
            return await _employeeDAL.DeleteAsync(id);
        }
    }
}
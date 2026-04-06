using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient; // Hoặc Microsoft.Data.SqlClient
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySolution.DomainModels; // Import lớp Employee đã tạo trước đó


namespace MySolution.DataLayers
{
    public class EmployeeDAL
    {
        private readonly string _connectionString;

        // Constructor nhận chuỗi kết nối
        public EmployeeDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Helper để tạo kết nối SQL
        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Lấy danh sách tất cả nhân viên
        /// </summary>
        public async Task<List<Employee>> ListAsync()
        {
            using (var connection = CreateConnection())
            {
                var sql = "SELECT * FROM Employee";
                var result = await connection.QueryAsync<Employee>(sql);
                return result.ToList();
            }
        }

        /// <summary>
        /// Lấy thông tin chi tiết một nhân viên theo ID
        /// </summary>
        public async Task<Employee> GetAsync(string id)
        {
            using (var connection = CreateConnection())
            {
                var sql = "SELECT * FROM Employee WHERE EmployeeId = @Id";
                // Dapper sẽ map tham số @Id với biến id truyền vào
                return await connection.QueryFirstOrDefaultAsync<Employee>(sql, new { Id = id });
            }
        }

        /// <summary>
        /// Bổ sung nhân viên mới
        /// </summary>
        public async Task<bool> AddAsync(Employee data)
        {
            using (var connection = CreateConnection())
            {
                var sql = @"
                    INSERT INTO Employee 
                    (EmployeeId, FirstName, LastName, BirthDate, Address, Email, Phone, Department) 
                    VALUES 
                    (@EmployeeId, @FirstName, @LastName, @BirthDate, @Address, @Email, @Phone, @Department)";

                // Dapper tự động map các thuộc tính của object 'data' vào các tham số @...
                var rowsAffected = await connection.ExecuteAsync(sql, data);
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên (KHÔNG cập nhật EmployeeId)
        /// </summary>
        public async Task<bool> UpdateAsync(Employee data)
        {
            using (var connection = CreateConnection())
            {
                // Lưu ý: Trong câu lệnh UPDATE dưới đây, EmployeeId chỉ nằm ở mệnh đề WHERE
                // để xác định dòng cần sửa, không nằm trong mệnh đề SET.
                var sql = @"
                    UPDATE Employee 
                    SET FirstName = @FirstName, 
                        LastName = @LastName, 
                        BirthDate = @BirthDate, 
                        Address = @Address, 
                        Email = @Email, 
                        Phone = @Phone, 
                        Department = @Department
                    WHERE EmployeeId = @EmployeeId";

                var rowsAffected = await connection.ExecuteAsync(sql, data);
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Xóa một nhân viên dựa vào ID
        /// </summary>
        public async Task<bool> DeleteAsync(string id)
        {
            using (var connection = CreateConnection())
            {
                var sql = "DELETE FROM Employee WHERE EmployeeId = @Id";
                var rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
                return rowsAffected > 0;
            }
        }
    }
}
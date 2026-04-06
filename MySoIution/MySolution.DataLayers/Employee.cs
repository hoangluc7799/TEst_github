using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolution.DataLayers
{
    public class Employee
    {
        // Khóa chính (Primary Key) - map với cột EmployeeId
        public string EmployeeId { get; set; }

        // Map với cột FirstName (ví dụ: Nguyễn, Trần...)
        public string FirstName { get; set; }

        // Map với cột LastName (ví dụ: Văn An, Thị Bình...)
        public string LastName { get; set; }

        // Map với cột BirthDate. Sử dụng DateTime cho kiểu ngày tháng.
        public DateTime BirthDate { get; set; }

        // Map với cột Address
        public string Address { get; set; }

        // Map với cột Email
        public string Email { get; set; }

        // Map với cột Phone. Nên để string để giữ số 0 ở đầu.
        public string Phone { get; set; }

        // Map với cột Department (ví dụ: Công nghệ thông tin...)
        public string Department { get; set; }

        // Optional: Thuộc tính tính toán (không có trong DB nhưng hữu ích trong code)
        public string FullName => $"{FirstName} {LastName}";
    }
}
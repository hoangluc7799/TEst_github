using Microsoft.AspNetCore.Mvc;
using MySolution.BusinessLayers;
using System.Threading.Tasks;

namespace MySolution.HRM.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = await HRMService.ListEmployeesAsync();
            return View(model);
        }

        // 1. GET: Hiển thị form thêm mới
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 2. POST: Nhận dữ liệu và lưu
        [HttpPost]
        public async Task<IActionResult> Create(MySolution.DataLayers.Employee model)
        {
            // Kiểm tra dữ liệu có hợp lệ không
            if (ModelState.IsValid)
            {
                // Gọi Service để thêm vào DB (Bạn cần đảm bảo HRMService có hàm AddEmployeeAsync)
                // Nếu HRMService chưa có, xem phần lưu ý cuối bài
                await HRMService.AddEmployeeAsync(model);

                // Thêm xong thì quay về trang danh sách
                return RedirectToAction("Index");
            }
            // Nếu lỗi thì hiện lại form cũ
            return View(model);
        }

    }


}

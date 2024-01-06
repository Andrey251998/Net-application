using Microsoft.AspNetCore.Mvc;
using Space_App_ASP_MVC.Models;
using spaceBLL.Interfaces;
using spaceBLL.Services;
using spaceBLL.UserDTO;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using AutoMapper;
using System.Data.Entity;
using spaceDAL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using spaceDAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Space_App_ASP_MVC.Controllers
{

    public class HomeController : Controller
    {

        public void MailMessage_Send(string polychatel, string Subject, string Body)
        {
            MailAddress from = new MailAddress("test.biba@mail.ru", "Уведомление о покупке");
            MailAddress to = new MailAddress(polychatel);
            MailMessage m = new MailMessage(from, to);

            m.Subject = Subject;
            m.Body = Body;

            SmtpClient smtp = new SmtpClient("smtp.mail.ru");

            smtp.Credentials = new NetworkCredential("test.biba@mail.ru", "NeDAbwe0UitP1XX5im7s");

            smtp.EnableSsl = true;

            smtp.Send(m);
        }

        IOrderService _context;
        public Application_context _application;
        

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IOrderService context,Application_context application)
        {

            _context = context;
            _application = application;
            _logger = logger;
           
           
        }
        
        
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public  IActionResult Index(LoginClient loginClient, RegisterClient RegisterClient)
        {
            if(ModelState.IsValid)
            {
                Models.Client cl =  _application.Clients.FirstOrDefault(u => u.Login == loginClient.Login && u.Password == loginClient.Password);
                if (cl != null)
                {
                    return RedirectToAction("users", "Home");
                }
                
                
            }
            if (ModelState.IsValid)
            {
                Models.Client user = _application.Clients.FirstOrDefault(u => u.Email == RegisterClient.Email);
                if (user == null)
                {

                    _application.Clients.Add(new Models.Client { Email = RegisterClient.Email, Password = RegisterClient.Password, Login = RegisterClient.Login });
                    _application.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        //Работа с users/////////////////////////
        public IActionResult users()
        {

            IEnumerable<spaceBLL.UserDTO.User> userDtos = _context.GetUsers();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<spaceBLL.UserDTO.User, Users>()).CreateMapper();
            var users = mapper.Map<IEnumerable<spaceBLL.UserDTO.User>, List<Users>>(userDtos);
            return View(users);

        }
        public IActionResult create()
        {

            return View();

        }
        [HttpPost]
        public IActionResult create(Users user)
        {
            var users = new spaceBLL.UserDTO.User { Name = user.Name, LastName = user.LastName, MidName = user.MidName, Date_Birthday = user.Date_Birthday };
            _context.addUser(users);

            return RedirectToAction("create");
        }


        //[HttpPost]
        //public async Task<ActionResult> delete(int id)
        //{


        //    if (id!=null)
        //    {
        //        Users us = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);

        //        if (us != null)
        //        {
        //            _context.Users.Remove(us); 
        //            _context.SaveChanges();
        //            RedirectToAction("users");
        //        }
        //    }



        //    return View();
        //}

        //public async Task<ActionResult> edit(int id)
        //{


        //    if (id != null)
        //    {
        //        Users us = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);

        //        if (us != null)
        //        {
        //            return View(us);
        //        }
        //    }

        //    return NotFound();
        //}

        //[HttpPost]
        //public async Task<IActionResult> edit(Users user)
        //{
        //    _context.Users.Update(user);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("users");
        //}
        ////Работа с Orders///////////////////////////////
        //public IActionResult orders()
        //{
        //    return View(_context.Orders.ToList());
        //}

        //public IActionResult create_order()
        //{

        //    ViewBag.use = new SelectList((from s in _context.Users.ToList() select new { Name = s.Name + " " + s.LastName, LastName = s.Name + " " + s.LastName }), "Name", "LastName");

        //    return View();
        //}


        //[HttpPost]
        //public async Task<IActionResult> create_order(Orders or)
        //{

        //    string jobID = BackgroundJob.Enqueue(() => MailMessage_Send("a.knyazev33@gmail.com","Покупка",$"Клиент {or.title} совершил покупку на сумму {or.Price}"));

        //    _context.Orders.Add(or);
        //    await _context.SaveChangesAsync();


        //    return RedirectToAction("okey");
        //}


        //[HttpPost]
        //public async Task<ActionResult> order_delete(int id)
        //{


        //    if (id != null)
        //    {
        //        Orders or = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);

        //        if (or != null)
        //        {
        //            _context.Orders.Remove(or);
        //            _context.SaveChanges();
        //            RedirectToAction("orders");
        //        }
        //    }

        //    return View();
        //}


        //public async Task<ActionResult> Edit_order(int id)
        //{


        //    if (id != null)
        //    {
        //        Orders or = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);

        //        if (or != null)
        //        {
        //            ViewBag.use = new SelectList(from s in _context.Users.ToList() select new { Name = s.Name + " " + s.LastName, LastName = s.Name + " " + s.LastName }, "Name", "LastName");

        //            return View(or);
        //        }
        //    }

        //    return NotFound();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit_order(Orders or)
        //{
        //    _context.Orders.Update(or);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("orders");
        //}

        //////////////////////////////////////////////////////////

        //public IActionResult okey()
        //{
        //    BackgroundJob.Schedule(()=>MailMessage_Send("a.knyazev33@gmail.com","test","сообщение пришло через 5 минут"),TimeSpan.FromSeconds(300));
        //    return View();
        //}



        /////RABBITMQ
        //public async Task<IActionResult> user_db_add()
        //{
        //    string Name;
        //    string firstName;
        //    string[] user = { };
        //    var factory = new ConnectionFactory() { HostName = "localhost" };
        //    using (var connection = factory.CreateConnection())
        //    using (var channel = connection.CreateModel())
        //    {
        //        channel.QueueDeclare(
        //         queue: "asp-net",
        //         durable: false,
        //         exclusive: false,
        //         autoDelete: false,
        //         arguments: null);


        //                var consumer = new EventingBasicConsumer(channel);
        //                 consumer.Received += async (sender, e) =>
        //                 {
        //                     var body = e.Body;
        //                     var message = Encoding.UTF8.GetString(body.ToArray());
        //                     user = message.Split(' ',StringSplitOptions.RemoveEmptyEntries);


        //                 };
        //        channel.BasicConsume(queue:"asp-net",
        //                             autoAck:true,
        //                             consumer:consumer);

        //    }
        //    try
        //    {
        //        Users us = new Users();
        //        us.Name = user[0];
        //        us.LastName = user[1];

        //        us.Date_Birthday = DateTime.Now;

        //        _context.Users.Add(us);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch(IndexOutOfRangeException) {

        //        return Content("Нету пользователей в очереди");
        //    }
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
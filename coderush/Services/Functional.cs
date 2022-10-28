using coderush.Data;
using coderush.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace coderush.Services
{
    public class Functional : IFunctional
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IRoles _roles;
        private readonly SuperAdminDefaultOptions _superAdminDefaultOptions;

        public Functional(UserManager<ApplicationUser> userManager,
           RoleManager<IdentityRole> roleManager,
           ApplicationDbContext context,
           SignInManager<ApplicationUser> signInManager,
           IRoles roles,
           IOptions<SuperAdminDefaultOptions> superAdminDefaultOptions)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _signInManager = signInManager;
            _roles = roles;
            _superAdminDefaultOptions = superAdminDefaultOptions.Value;
        }

      

        public async Task InitAppData()
        {
            try
            {
               
                await _context.BillType.AddAsync(new BillType { BillTypeName = "Mặc định" });
                await _context.SaveChangesAsync();

                await _context.Branch.AddAsync(new Branch { BranchName = "Mặc định" });
                await _context.SaveChangesAsync();

                await _context.Warehouse.AddAsync(new Warehouse { WarehouseName = "Mặc định" });
                await _context.SaveChangesAsync();

                await _context.CashBank.AddAsync(new CashBank { CashBankName = "Mặc định" });
                await _context.SaveChangesAsync();

                await _context.Currency.AddAsync(new Currency { CurrencyName = "Mặc định", CurrencyCode = "VNĐ" });
                await _context.SaveChangesAsync();

                await _context.InvoiceType.AddAsync(new InvoiceType { InvoiceTypeName = "Mặc định" });
                await _context.SaveChangesAsync();

                await _context.PaymentType.AddAsync(new PaymentType { PaymentTypeName = "Mặc định" });
                await _context.SaveChangesAsync();

                await _context.PurchaseType.AddAsync(new PurchaseType { PurchaseTypeName = "Mặc định" });
                await _context.SaveChangesAsync();

                await _context.SalesType.AddAsync(new SalesType { SalesTypeName = "Mặc định" });
                await _context.SaveChangesAsync();

                await _context.ShipmentType.AddAsync(new ShipmentType { ShipmentTypeName = "Mặc định" });
                await _context.SaveChangesAsync();

                await _context.UnitOfMeasure.AddAsync(new UnitOfMeasure { UnitOfMeasureName = "Chiếc" });
                await _context.SaveChangesAsync();

                await _context.ProductType.AddAsync(new ProductType { ProductTypeName = "Mặc định" });
                await _context.SaveChangesAsync();

                List<Product> products = new List<Product>() {
                    new Product{ProductName = "Quần Jean"},
                    new Product{ProductName = "Áo sơ mi"},
                    new Product{ProductName = "Quần tây"},
                    new Product{ProductName = "Quần thể dục"},
                    new Product{ProductName = "Giày"},
                 

                };
                await _context.Product.AddRangeAsync(products);
                await _context.SaveChangesAsync();

                await _context.CustomerType.AddAsync(new CustomerType { CustomerTypeName = "Mặc định" });
                await _context.SaveChangesAsync();

                List<Customer> customers = new List<Customer>() {
                    new Customer{CustomerName = "Nguyễn Hoàng Kiệt", Address = "TP Cao Lãnh, Đồng Tháp"},
                    new Customer{CustomerName = "Lê Minh Quân", Address = "TP Cao Lãnh, Đồng Tháp"},
                    new Customer{CustomerName = "Trần Quốc Thắng", Address = "TP HCM"},
                };
                await _context.Customer.AddRangeAsync(customers);
                await _context.SaveChangesAsync();

                await _context.VendorType.AddAsync(new VendorType { VendorTypeName = "Mặc định" });
                await _context.SaveChangesAsync();

                List<Vendor> vendors = new List<Vendor>() {
                    new Vendor{VendorName = "Nhà cung cấp A", Address = "TP HCM"},
                    new Vendor{VendorName = "Nhà cung cấp B", Address = "TP HCM"},
                    new Vendor{VendorName = "Nhà cung cấp C", Address = "TP HCM"},
                };
                await _context.Vendor.AddRangeAsync(vendors);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SendEmailBySendGridAsync(string apiKey, 
            string fromEmail, 
            string fromFullName, 
            string subject, 
            string message, 
            string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(fromEmail, fromFullName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email, email));
            await client.SendEmailAsync(msg);

        }

        public async Task SendEmailByGmailAsync(string fromEmail,
            string fromFullName,
            string subject,
            string messageBody,
            string toEmail,
            string toFullName,
            string smtpUser,
            string smtpPassword,
            string smtpHost,
            int smtpPort,
            bool smtpSSL)
        {
            var body = messageBody;
            var message = new MailMessage();
            message.To.Add(new MailAddress(toEmail, toFullName));
            message.From = new MailAddress(fromEmail, fromFullName);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = smtpUser,
                    Password = smtpPassword
                };
                smtp.Credentials = credential;
                smtp.Host = smtpHost;
                smtp.Port = smtpPort;
                smtp.EnableSsl = smtpSSL;
                await smtp.SendMailAsync(message);

            }

        }

        public async Task CreateDefaultSuperAdmin()
        {
            try
            {
                await _roles.GenerateRolesFromPagesAsync();

                ApplicationUser superAdmin = new ApplicationUser();
                superAdmin.Email = _superAdminDefaultOptions.Email;
                superAdmin.UserName = superAdmin.Email;
                superAdmin.EmailConfirmed = true;

                var result = await _userManager.CreateAsync(superAdmin, _superAdminDefaultOptions.Password);

                if (result.Succeeded)
                {
                    //add to user profile
                    UserProfile profile = new UserProfile();
                    profile.FirstName = "Super";
                    profile.LastName = "Admin";
                    profile.Email = superAdmin.Email;
                    profile.ApplicationUserId = superAdmin.Id;
                    await _context.UserProfile.AddAsync(profile);
                    await _context.SaveChangesAsync();

                    await _roles.AddToRoles(superAdmin.Id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<string> UploadFile(List<IFormFile> files, IHostingEnvironment env, string uploadFolder)
        {
            var result = "";

            var webRoot = env.WebRootPath;
            var uploads = System.IO.Path.Combine(webRoot, uploadFolder);
            var extension = "";
            var filePath = "";
            var fileName = "";


            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    extension = System.IO.Path.GetExtension(formFile.FileName);
                    fileName = Guid.NewGuid().ToString() + extension;
                    filePath = System.IO.Path.Combine(uploads, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    result = fileName;

                }
            }

            return result;
        }

    }
}

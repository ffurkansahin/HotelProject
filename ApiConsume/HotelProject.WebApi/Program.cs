using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<Context>();
            builder.Services.AddScoped<IStaffDAL,EfStaffDAL>();
            builder.Services.AddScoped<IStaffService,StaffManager>();

            builder.Services.AddScoped<IServicesDAL, EfServiceDAL>();
            builder.Services.AddScoped<IServiceService, ServiceManager>();

            builder.Services.AddScoped<IRoomDAL, EfRoomDAL>();
            builder.Services.AddScoped<IRoomService, RoomManager>();

            builder.Services.AddScoped<ISubscribeDAL, EfSubscribeDAL>();
            builder.Services.AddScoped<ISubscribeService, SubscribeManager>();

            builder.Services.AddScoped<ITestimonialDAL, EfTestimonialDAL>();
            builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

            builder.Services.AddScoped<IAboutDAL, EfAboutDAL>();
            builder.Services.AddScoped<IAboutService, AboutManager>();

            builder.Services.AddScoped<IBookingDAL,EfBookingDAL>();
            builder.Services.AddScoped<IBookingService,BookingManager>();

            builder.Services.AddScoped<IContactDAL,EfContactDAL>();
            builder.Services.AddScoped<IContactService,ContactManager>();

            builder.Services.AddScoped<IGuestService,GuestManager>();
            builder.Services.AddScoped<IGuestDAL, EfGuestDAL>();

            builder.Services.AddScoped<ISendMessageService,SendMessageManager>();
            builder.Services.AddScoped<ISendMessageDAL,EfSendMessageDAL>();

            builder.Services.AddScoped<IMessageCategoryService, MessageCategoryManager>();
            builder.Services.AddScoped<IMessageCategoryDAL, EfMessageCategoryDAL>();
            
            builder.Services.AddScoped<IWorkLocationService, WorkLocationManager>();
            builder.Services.AddScoped<IWorkLocationDAL, EfWorkLocationDAL>();

            builder.Services.AddScoped<IAppUserService, AppUserManager>();
            builder.Services.AddScoped<IAppUserDAL, EfAppUserDAL>();


            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("HotelApiCors", opts =>
                {
                    opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            builder.Services.AddControllers().AddNewtonsoftJson(options=>options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("HotelApiCors");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
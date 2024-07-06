using Vidly.Data;
using Vidly.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();





//using ApplicationDbContext context = new ApplicationDbContext();


//Genre typeOne = new Genre
//{
//    Id = 1,
//    Name = "Action"
//};

//Genre typeTwo = new Genre
//{
//    Id = 2,
//    Name = "Comedy"
//};

//Genre typeThree = new Genre
//{
//    Id = 3,
//    Name = "Family"
//};

//Genre typeFour = new Genre
//{
//    Id = 4,
//    Name = "Romance"
//};

//context.Add(typeOne);
//context.Add(typeTwo);
//context.Add(typeThree);
//context.Add(typeFour);

//context.SaveChanges();



//MemberShipType typeOne = new MemberShipType
//{
//    Id = 1,
//    SignupFee = 0,
//    DurationInMonths = 0,
//    DiscountRate = 0
//};


//MemberShipType typeTwo = new MemberShipType
//{
//    Id = 2,
//    SignupFee = 30,
//    DurationInMonths = 1,
//    DiscountRate = 10
//};

//MemberShipType typeThree = new MemberShipType
//{
//    Id = 3,
//    SignupFee = 90,
//    DurationInMonths = 3,
//    DiscountRate = 15
//};


//MemberShipType typeFour = new MemberShipType
//{
//    Id = 4,
//    SignupFee = 300,
//    DurationInMonths = 12,
//    DiscountRate = 20
//};

////context.Add(typeOne);
//context.Add(typeTwo);
//context.Add(typeThree);
//context.Add(typeFour);

//context.SaveChanges();
using System;
using System.Text;
using BT.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace BT.Infrastructure.Persistence
{
    public static class DataSeed
    {
        private static readonly string LoremIpsum = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Duis semper purus venenatis diam pulvinar, vitae porttitor sem ornare. Vivamus interdum viverra
            mattis. Proin sodales neque massa, et pulvinar lectus accumsan non. Mauris blandit, mi vel 
            facilisis posuere, quam mauris rutrum est, nec auctor lorem libero pretium elit. Nunc hendrerit 
            euismod urna, eget viverra est condimentum a. Nunc mattis porta cursus. Nulla finibus lobortis est 
            a viverra. Duis consequat neque eget ligula sodales sodales. Curabitur scelerisque ac nulla eget hendrerit. 
            Duis nec nunc id eros lacinia ullamcorper. Cras porttitor, sapien vulputate fermentum sagittis, nibh dolor 
            aliquam velit, a sodales tortor lectus sit amet quam. Phasellus tempor sollicitudin porttitor. In eu sapien 
            a ipsum sollicitudin malesuada quis a elit. Integer sit amet fringilla dui. In viverra vel velit nec posuere. 
            Proin sed nisi tempus, placerat nisi at, imperdiet libero. Suspendisse sollicitudin risus ante, eget rutrum 
            dui sagittis et. Maecenas commodo sagittis ligula, vitae fringilla ligula mollis sit amet. In hac habitasse 
            platea dictumst. Suspendisse vehicula nulla luctus, mollis risus id, consectetur libero. Integer interdum 
            varius justo. Nam finibus fringilla leo eu lacinia.";

        public static void Seed(this ModelBuilder builder)
        {
            byte[] salt = Encoding.ASCII.GetBytes("bt-salt");
            var user1 = new User("admin@bt.com", "Aleksaner", "Ciechanowski", "123456", salt);
            var user2 = new User("admin1@bt.com", "Donald", "Lukaszenka", "123456", salt);
            var user3 = new User("admin2@bt.com", "Andrzej", "Kaczynski", "123456", salt);

            builder.Entity<User>().HasData(
                user1, user2, user3,
                new User("btmail@bt.com", "Jack", "Nowak", "123456", salt),
                new User("btmail1@bt.com", "George", "Bush", "123456", salt),
                new User("btmail2@bt.com", "Alina", "Ivanov", "123456", salt),
                new User("btmail3@bt.com", "Ksenya", "Barbie", "123456", salt)
            );

            var category = new Category("Basketball");
            var category1 = new Category("Football");
            var category2 = new Category("Hokey");
            var category3 = new Category("Running");
            var category4 = new Category("Ski");

            builder.Entity<Category>().HasData(
                category, category1, category2, category3, category4
            );

            builder.Entity<Meeting>().HasData(
                new Meeting("Find people to play basketball", LoremIpsum, 12, DateTime.UtcNow, user1.Id, category.Id),
                new Meeting("Find 6 guys to our basketball team", LoremIpsum, 6, DateTime.UtcNow, user3.Id, category.Id),
                new Meeting("Find friends to casual play", LoremIpsum, 21, DateTime.UtcNow, user2.Id, category1.Id),
                new Meeting("Footboll tomorrow", LoremIpsum, 3, DateTime.UtcNow, user1.Id, category1.Id),
                new Meeting("Find team to game", LoremIpsum, 6, DateTime.UtcNow, user3.Id, category2.Id),
                new Meeting("ICE IS COLD. THIS WEEKEND", LoremIpsum, 12, DateTime.UtcNow, user2.Id, category2.Id),
                new Meeting("Find somebody to running together", LoremIpsum, 2, DateTime.UtcNow, user3.Id, category3.Id),
                new Meeting("Marathon", LoremIpsum, 100, DateTime.UtcNow, user1.Id, category3.Id),
                new Meeting("Ski in Tatry", LoremIpsum, 1, DateTime.UtcNow, user1.Id, category4.Id),
                new Meeting("Ski next winter group", LoremIpsum, 12, DateTime.UtcNow, user2.Id, category4.Id)
            );
        }
    }
}
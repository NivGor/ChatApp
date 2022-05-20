using ChatAppWebAPI.Models;

namespace ChatWebAPI.Models
{
    public class StaticDB
    {
        
        public static List<Message> messages = new List<Message>() { new Message(){Id = 5, Content = "bla bla",
              Created = DateTime.Now, Sent =  true }, new Message(){Id = 6, Content = "bla bla2222",
              Created = DateTime.Now, Sent =  false } };

        public static List<Message> messages2 = new List<Message>() { new Message(){Id = 7, Content = "new bla3",
              Created = DateTime.Now, Sent =  true }, new Message(){Id = 8, Content = "new bla4",
              Created = DateTime.Now, Sent =  false } };

        public static List<Contact> contacts = new List<Contact>() {
            new Contact() { Id = "1", Last = "a", Name = "mojo jojo",
                                        LastDate = DateTime.Now, Server = "server", messages = messages},
            new Contact() { Id = "2", Last = "a2", Name = "mojo jojo2",
                                        LastDate = DateTime.Now, Server = "server" , messages = messages2},
        new Contact() { Id = "3", Last = "a2", Name = "mojo jojo3",
                                        LastDate = DateTime.Now, Server = "server"}};

        public static List<User> users = new List<User>() { new User() { Username = "mojo", DisplayName = "jojo",
                                                            Password = "123456a", Contacts = contacts} };

    }
}

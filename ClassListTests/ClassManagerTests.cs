using AutoFixture;
using ClassList;
using ClassList.Models;

namespace ClassListTests
{
    public class ClassManagerTests
    {
        private readonly IFixture _fixture;

        public ClassManagerTests()
        {
            _fixture = new Fixture();
        }

        [Test]
        public void AddNewGroupTest()
        {
            var users = _fixture.CreateMany<User>(9).ToList();
            var group = _fixture.Build<Group>()
                .With(x => x.Users, users)
                .Create();
            Console.WriteLine(group.Users.Count);
            var classManager = new ClassManager();


            Assert.IsTrue(classManager.AddNewGroup(group));
            Assert.IsFalse(classManager.AddNewGroup(group));
        }

        [Test]
        public void AddNewUserToClassTest() 
        {
            var group = _fixture.Build<Group>()
                .With(x => x.Users, new List<User>())
                .Create();
            var classManager = new ClassManager();
            classManager.AddNewGroup(group);

            var user = _fixture.Create<User>();
            Assert.IsTrue(classManager.AddNewUserToClass(user, group.Id));

            Assert.Catch<NullReferenceException>(() => classManager.AddNewUserToClass(_fixture.Create<User>(), group.Id + 1));
        }

        [Test]
        public void GetUserByIdTest()
        {
            var users = _fixture.CreateMany<User>(20).ToList();
            var group = _fixture.Build<Group>()
                .With(x => x.Users, users)
                .Create();
            var classManager = new ClassManager();
            classManager.AddNewGroup(group);

            var userInClass = users.First();
            Assert.That(classManager.GetUserById(userInClass.Id), Is.SameAs(userInClass));

            var idNotInGroup = users.Select((u) => u.Id).Max() + 1;
            Assert.IsNull(classManager.GetUserById(idNotInGroup));
        }

        [Test]
        public void CreateUserTest()
        {
            var group = _fixture.Build<Group>()
                .With(x => x.Users, new List<User>())
                .Create();
            var classManager = new ClassManager();
            classManager.AddNewGroup(group);

            var (id, firstName, lastName) = (_fixture.Create<int>(), _fixture.Create<string>(), _fixture.Create<string>());
            var user = classManager.CreateUser(id, firstName, lastName);

            Assert.IsInstanceOf<User>(user);
            Assert.Catch<ArgumentNullException>(() => classManager.CreateUser(id + 1, null, "dnasja"));
            Assert.Catch<ArgumentNullException>(() => classManager.CreateUser(id + 1, "dnasja", null));

            classManager.AddNewUserToClass(user, group.Id);
            Assert.Catch<Exception>(() => classManager.CreateUser(id, firstName, lastName));
        }

        [Test]
        public void RemoveUserByIdTest()
        {
            var group = _fixture.Build<Group>()
                .With(x => x.Users, new List<User>())
                .Create();
            var classManager = new ClassManager();
            classManager.AddNewGroup(group);

            var user = _fixture.Create<User>();
            classManager.AddNewUserToClass(user, group.Id);
            
            Assert.IsInstanceOf<User>(classManager.GetUserById(user.Id));
            classManager.RemoveUserById(group.Id);
            Assert.IsNull(classManager.GetUserById(group.Id));
        }
        [Test]
        public void EditUserByIdTest()
        {
            var users = _fixture.CreateMany<User>(20).ToList();
            var group = _fixture.Build<Group>()
                .With(x => x.Users, users)
                .Create();
            var classManager = new ClassManager();
            classManager.AddNewGroup(group);

            Assert.IsTrue(classManager.EditUserById(users.First().Id, "dsadas", "dsda"));
            var idThatDoesntExist = users.Select(x => x.Id).Max() + 1;
            Assert.IsFalse(classManager.EditUserById(idThatDoesntExist, "dsadas", "dsda"));
        }
    }
}
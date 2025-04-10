using SistemaDeComentariosBackend.Entitites;
using SistemaDeComentariosBackend.Repository;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            List<Comment> comments = new List<Comment>{
                                            new Comment { Id = 1, Body = "Primero", ImageId = 1, UserId = 1 },
                                            new Comment { Id = 2, Body = "segundo", ImageId = 1, UserId = 1 },
                                            new Comment { Id = 3, Body = "tercero", ImageId = 1, UserId = 1 }
             };

        }
    }
}
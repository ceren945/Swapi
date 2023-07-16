namespace StarWarsApi.Models.ResponseModels
{
    public class FilmsResponse:BaseResponse<Films>
    {
          
      
    }
}

// Star Wars API'dan gelen filmlerle ilgili bilgilere erişmek için kullanılan bir yanıt modelidir.
// Bu sınıf, API'den alınan verilerin belirli bir formatını temsil eder.
//İşlevsel olarak, FilmsResponse sınıfı, API'nin döndürdüğü film verilerinin toplu bir yanıtını temsil eder. İçerdiği özellikler şunlardır:

//count: API yanıtında bulunan film sayısını temsil eder.
//next: API yanıtında, bir sonraki sayfaya geçmek için kullanılan bir URL'yi temsil eder. Eğer bir sonraki sayfa yoksa, bu alan boş olabilir.
//previous: API yanıtında, bir önceki sayfaya geçmek için kullanılan bir URL'yi temsil eder. Eğer bir önceki sayfa yoksa, bu alan boş olabilir.
//results: API yanıtında bulunan filmlerin listesini temsil eder. Her film, Films sınıfının bir örneği olarak temsil edilir.

//bir API isteği yapıldığında, bu sınıf, JSON yanıtın dönüştürülmesiyle birlikte kullanılır ve film verilerine erişmek için kullanıcıya yardımcı olur.

//Özetle, FilmsResponse sınıfı, Star Wars API'den gelen film verilerini temsil eder ve bu verilere erişim sağlayarak API yanıtlarını kolayca yönetmeyi amaçlar.
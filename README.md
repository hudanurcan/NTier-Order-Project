** validator katmanı **

response ve request modelleri ayrı bir katmana çekmek zorunda kaldım. çünkü validator katmanını eklediğim zaman referansları düzgün ayarlayamadım. onları ayrı bir katmana alınca düzeldi. Concrats katmanı aslında ViewModels katmanı olmalıydı. Ama sonradan değiştiremediğim için bu şekilde kaldı.

validator katmanı oluşturdum. burda response, request ve entityler için ayrı klasörlerde validasyonları tanımladım. burada appuser ve appuserprofile da ortak id atamasını ayarladım. yani önce appuser oluşturuluyor. daha sonra oluşturulan appuser için appuserprofile oluşturuluyor ve bunların id leri aynı oluyor ( önce appuser oluştuğu için onun id si)


** hata yönetimi **
Bll katmanına Executors klasörünü oluşturdum. tek bir yerde hem geri dönüş tipli hem de geri dönüş tipsiz try catch blokları yazdım. bu sayede basemanager'da try catch kullanmamış oldum.
Exceptions klasörü ise bll deki hataları ayırabilmek için ayrı bir klasörde tuttum.

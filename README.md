### 🎯 Projeye Genel Bakış
Projenin Amacı
Bu proje, JWT ve Identity kullanarak bir API'de kullanıcı kimlik doğrulama ve yetkilendirme işlemlerini yönetmenin temel adımlarını öğretmektedir. Kullanıcı kaydı, oturum açma ve yetkilendirilmiş kullanıcılar için ürün listeleme gibi işlevsellikler geliştirilmiştir.

Projenin amacı, JWT kullanarak stateless bir kimlik doğrulama mekanizması sağlamak ve bunun yanında ASP.NET Core Identity ile kullanıcı yönetimini entegre etmektir. Ayrıca, kullanıcıların yalnızca yetkilendirilmiş erişimle belirli verilere ulaşabilmesi için API'lerde güvenli erişim yöntemlerini incelemektir.

Bileşenler:
Controllers: API endpoint'lerini içerir. Kullanıcı kaydı, giriş işlemi ve ürünler üzerinde işlemler yapılır.

Models: Kullanıcı ve ürün gibi veri modellerini içerir.

Services: JWT oluşturma ve doğrulama işlemlerini yöneten servisler bulunur.

Context: Veritabanı işlemleri için Entity Framework Core kullanılarak veri tabanı bağlamı (DbContext) tanımlanmıştır.

## 🔑 JWT Nedir?
JSON Web Token (JWT), JSON formatında oluşturulan ve güvenli bir şekilde kullanıcı bilgilerini taşıyan bir token’dır. Kullanıcı, sistemde oturum açtıktan sonra bir JWT oluşturulur ve bu token, kullanıcıyı tanımak ve yetkilendirmek için sunucu tarafından kullanılır.

# JWT'nin avantajları şunlardır:

Stateless: Sunucu her istekte kullanıcı bilgilerini saklamak zorunda kalmaz.

Güvenli: Token, dijital imza ile güvence altına alınabilir.

Taşınabilir: JSON formatı sayesinde farklı sistemler arasında kolayca taşınabilir.

 ## 🧩 JWT'nin Yapısı

JWT üç ana bileşenden oluşur:

Header: Hangi algoritmanın kullanıldığını belirtir (örneğin, HMAC SHA256 veya RSA).

Payload: Kullanıcıya dair bilgilerin (claims) bulunduğu kısımdır. Bu bilgiler, kullanıcının kimliği, yetkileri vb. olabilir.

Signature: Token’ın doğruluğunu doğrulamak için kullanılan dijital imza kısmıdır.

Örnek JWT yapısı:

<Header>.<Payload>.<Signature>

## JWT ile Identity Kullanımı

Bu projede, ASP.NET Core Identity ile kullanıcı yönetimi sağlanır. JWT ise kullanıcıların kimlik doğrulaması ve API erişim yetkilendirmesi için kullanılır.

# Adımlar:

Kullanıcı Kaydı: Kullanıcılar sisteme kaydolur.

Giriş Yapma: Kullanıcı, kullanıcı adı ve şifre ile giriş yapar.

JWT Oluşturma: Giriş işlemi başarılı olursa, sunucu bir JWT oluşturur ve istemciye gönderir.

Authorization: İstemci, API istekleri sırasında JWT'yi Authorization başlığı ile gönderir.

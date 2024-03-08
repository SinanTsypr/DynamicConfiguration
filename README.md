<h1>Giriş</h1>

<h2>Projenin Amacı:</h2>

<p>Bu proje, <code>web.config</code>, <code>app.config</code>, <code>appsettings.json</code> gibi dosyalarda tutulan appkey'lerin ortak ve dinamik bir yapıyla erişilebilir olması ve deployment veya restart, recycle gerektirmeden güncellemelerin yapılabilir olması için dinamik bir konfigürasyon yapısı oluşturmak için geliştirilmiştir.</p>

<h2>Genel Bilgiler:</h2>

<p><strong>Proje Adı:</strong> SecilStore</p>
<p><strong>Teknolojiler:</strong></p>
<ul>
  <li><strong>Mimari:</strong> Onion Architecture</li>
  <li><strong>Veritabanı:</strong> MongoDB</li>
  <li><strong>Programlama Dili:</strong> C#</li>
  <li><strong>Framework:</strong> ASP.NET 8.0</li>
  <li><strong>Sürüm Kontrol:</strong> Github</li>
  <li><strong>Docker:</strong> Docker Compose</li>
</ul>

<h2>Özellikler:</h2>
<ul>
  <li>Dinamik konfigürasyon yapısı</li>
  <li>Uygulama bazlı erişim</li>
  <li>Tip dönüştürme</li>
  <li>Docker desteği</li>
  <li>Unit Test altyapısı(Moq kütüphanesi yüklendi)<b>(tamamlanmadı)</b></li>
</ul>

<h1>Mimari</h1>

<h2>Onion Architecture:</h2>

<p>Onion Architecture, katmanlı bir yazılım mimarisidir. Bu mimaride her katman, bir üst katmana hizmet verir ve bir alt katmandan bağımsızdır. Bu sayede kod daha modüler, test edilebilir ve bakımı kolay hale gelir.</p>

<h2>Katmanlar ve Sınıflar:</h2>

<ul>
  <li><strong>Application:</strong> Bu katman, iş mantığını içerir.</li>
  <li><strong>Domain:</strong> Bu katman, projenin domain modelini içerir.</li>
  <li><strong>Infrastructure:</strong> Bu katman, veritabanı erişimi, logging gibi altyapı hizmetlerini içerir.</li>
  <li><strong>Persistence:</strong> Bu katman, veritabanı ile etkileşimi içerir.</li>
  <li><strong>UI:</strong> Bu katman, kullanıcı arayüzünü içerir.</li>
</ul>

<h1>Veritabanı</h1>

<h2>Kullanılan Veritabanı:</h2>
<p>MongoDB</p>

<h2>Tablo Şeması:</h2>

<table>
  <thead>
    <tr>
      <th>Alan</th>
      <th>Veri Tipi</th>
      <th>Not</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Id</td>
      <td>String (Primary Key)</td>
      <td></td>
    </tr>
    <tr>
      <td>ApplicationName</td>
      <td>String</td>
      <td></td>
    </tr>
    <tr>
      <td>Key</td>
      <td>String</td>
      <td></td>
    </tr>
    <tr>
      <td>Value</td>
      <td>String</td>
      <td></td>
    </tr>
    <tr>
      <td>Type</td>
      <td>String</td>
      <td></td>
    </tr>
    <tr>
      <td>IsActive</td>
      <td>Boolean</td>
      <td></td>
    </tr>
  </tbody>
</table>

<h2>Veritabanına Erişim:</h2>

<p>Veritabanına erişim için Entity Framework Core ve MongoDB.Driver kütüphaneleri kullanılmaktadır.</p>

<h1>Kütüphane Kullanımı</h1>

<h2>ConfigurationReader Kütüphanesi:</h2>

<p>Bu kütüphane, dinamik konfigürasyonlara erişmek için kullanılır.</p>

<h2>Initialize Etme:</h2>

<pre><code>services.AddSingleton(s => new ConfigurationReader("applicationName", "connecttionString", 30000));
</code></pre>

<h2>GetValue&lt;T&gt; Metodu:</h2>

<p>Bu metot, bir konfigürasyon kaydının değerini döndürmek için kullanılır.</p>

<pre><code>var siteName = configurationReader.GetValue&lt;string&gt;("SiteName");
</code></pre>

<h1>Web UI</h1>

<h2>CRUD İşlemleri:</h2>

<p>Web UI, konfigürasyon kayıtlarını eklemek, düzenlemek ve silmek için CRUD işlemleri sunar.</p>

<h2>Filtreleme:</h2>

<p>Kullanıcılar, konfigürasyon kayıtlarını isim ile filtreleyebilir.</p>

<h1>Docker</h1>

<h2>Docker Compose Dosyası:</h2>

<p>Bu dosya, projeyi Docker ile ayağa kaldırmak için gerekli tüm bilgileri içerir.</p>

<h2>Projeyi Docker ile Ayağa Kaldırma:</h2>

<pre><code>docker-compose up
</code></pre>

<h1>Unit Test</h1>

<h2>Unit Test Altyapısı:</h2>

<p>Unit test altyapısı, Moq kütüphanesi kullanılarak kurulmuştur. Ancak gerekli UnitTestler <b>yapılamamıştır.</b></p>

<h1>Proje Görseli</h1>
<img src="https://github.com/SinanTsypr/DynamicConfiguration/assets/85941907/b98cb611-a95b-461d-9ba3-ec470c4181d7" alt="Web">
<img src="https://github.com/SinanTsypr/DynamicConfiguration/assets/85941907/e5c279c5-1d0c-465a-859d-551fed2e71ad" alt="Service-A">
<img src="https://github.com/SinanTsypr/DynamicConfiguration/assets/85941907/8e47b1f8-61ec-4aaf-a0c5-9364cd680bf1" alt="Service-B">


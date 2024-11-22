using Gestion_Academica.Data.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.Extensions;
using Xunit;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SeleniumTests
{
    public class LocalhostEdgeTests
    {
        private readonly IWebDriver _driver;
        private readonly string _baseUrl = "http://localhost:5015/";
        private ExtentReports _extentReports;
        private ExtentTest _test;

        public LocalhostEdgeTests()
        {
            // Configurar el controlador de Edge
            var options = new EdgeOptions();
            _driver = new EdgeDriver(options);

            // Configurar ExtentReports
            var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Tested", "ExtentReport.html");
            var sparkReporter = new ExtentSparkReporter(reportPath);
            sparkReporter.Config.DocumentTitle = "Reporte de Pruebas Selenium";
            sparkReporter.Config.ReportName = "Pruebas Automatizadas con Selenium";
            sparkReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;


            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(sparkReporter);
        }

        private void TakeScreenshot(string fileName)
        {
            //las capturas de pantalla se guardaran en el directorio de bin/debug/net8.0/Screenshots
            string directoryPath = "./Screenshots/";

            // Verifica si el directorio existe, si no, lo crea
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

          
            var screenshot = _driver.TakeScreenshot();

            // Guarda la captura de pantalla en el directorio especificado
            screenshot.SaveAsFile($"{directoryPath}{fileName}.png");
        }

        [Fact]
        public void Test_HomePageTitle()
        {
            // Informacion para el reporte
            _test = _extentReports.CreateTest("Test_HomePageTitle")
                                  .Info("Verificar el título de la página de inicio.");
            // Navegar a la URL base
            _driver.Navigate().GoToUrl(_baseUrl);

            // Verificar el título de la página
            Assert.Equal("Home Page - Gestion_Academica.Web", _driver.Title);

            _test.Pass("El título de la página de inicio es correcto.");
            TakeScreenshot("HomePageTittle");
        }

        [Fact]
        public void Test_IndexProfesoresTitle()
        {

            _test = _extentReports.CreateTest("Test_IndexProfesoresTitle")
                                  .Info("Verificar el título de la página de Profesores.");

            // Navegar a la URL base
            _driver.Navigate().GoToUrl(_baseUrl);

            // Encontrar el botón por su texto
            var button = _driver.FindElement(By.LinkText("Profesores"));
            button.Click();

            // Verificar el título de la página
            Assert.Equal("Profesores - Gestion_Academica.Web", _driver.Title);

            _test.Pass("El título de la página de Profesores es correcto.");
            TakeScreenshot("IndexProfesoresTitle");
        }

        [Fact]
        public void Test_IndexEstudiantesTitle()
        {
            _test = _extentReports.CreateTest("Test_IndexEstudiantesTitle")
                                  .Info("Verificar el título de la página de Estudiantes.");
            // Navegar a la URL base
            _driver.Navigate().GoToUrl(_baseUrl);

            // Encontrar el botón por su texto
            var button = _driver.FindElement(By.LinkText("Estudiantes"));
            button.Click();

            // Verificar el título de la página
            Assert.Equal("Estudiantes - Gestion_Academica.Web", _driver.Title);

            _test.Pass("El título de la página de Estudiantes es correcto.");
            TakeScreenshot("IndexEstudiantesTitle");
        }

        [Fact]
        public void Test_IndexCarrerasTitle()
        {
            _test = _extentReports.CreateTest("Test_IndexCarrerasTitle")
                      .Info("Verificar el título de la página de Carreras.");

            // Navegar a la URL base
            _driver.Navigate().GoToUrl(_baseUrl);

            // Encontrar el botón por su texto
            var button = _driver.FindElement(By.LinkText("Carreras"));
            button.Click();

            // Verificar el título de la página
            Assert.Equal("Carreras - Gestion_Academica.Web", _driver.Title);

            _test.Pass("El título de la página de Carreras es correcto.");
            TakeScreenshot("IndexCarrerasTitle");
        }

        [Fact]
        public void Test_HomePrivacyTitle()
        {
            _test = _extentReports.CreateTest("Test_HomePrivacyTitle")
                      .Info("Verificar el título de la página de Privacidad.");

            // Navegar a la URL base
            _driver.Navigate().GoToUrl(_baseUrl);

            // Encontrar el botón por su texto
            var button = _driver.FindElement(By.LinkText("Privacy"));
            button.Click();

            // Verificar el título de la página
            Assert.Equal("Privacy Policy - Gestion_Academica.Web", _driver.Title);

            _test.Pass("El título de la página de Privacidad es correcto.");
            TakeScreenshot("HomePrivacyTittle");
        }

        [Fact]
        public void Test_ClickButtonAndVerifyTitle()
        {
            _test = _extentReports.CreateTest("Test_ClickButtonAndVerifyTitle")
                      .Info("Verificar el título de la página de crear estudiantes.");
            // Navegar a la página
            _driver.Navigate().GoToUrl($"{_baseUrl}Estudiante");

            // Encontrar el botón por su texto
            var button = _driver.FindElement(By.LinkText("Crear nuevo estudiante"));
            button.Click();

            // Verificar que la acción genera el resultado esperado
            Assert.Equal("Crear estudiante - Gestion_Academica.Web", _driver.Title);

            _test.Pass("El título de la página de crear estudiantes es correcto.");
            TakeScreenshot("CreateStudentTittle");
        }

        [Fact]
        public void Test_RegisterNewEstudiante()
        {
            _test = _extentReports.CreateTest("Test_RegisterNewEstudiante")
                                  .Info("Registrar un nuevo estudiante.");
            // Navegar a la página de "Crear nuevo estudiante"
            _driver.Navigate().GoToUrl($"{_baseUrl}Estudiante/Create");

            // Ingresar datos en los campos del formulario
            _driver.FindElement(By.Id("Id")).SendKeys("11");
            _driver.FindElement(By.Id("Nombre")).SendKeys("Ana");
            _driver.FindElement(By.Id("Apellido")).SendKeys("García");
            _driver.FindElement(By.Id("Matricula")).SendKeys("2024-0001");
            _driver.FindElement(By.Id("Fecha_nacimiento")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("document.getElementById('Fecha_nacimiento').value = '2024-01-20T00:00';");
            _driver.FindElement(By.Id("Cedula")).SendKeys("001-23456789-0");
            _driver.FindElement(By.Id("Sexo")).SendKeys("F");
            _driver.FindElement(By.Id("Becado")).SendKeys("S");

            TakeScreenshot("FilledStudentData");
            // Hacer clic en el botón de "Crear Estudiante"
            var submitButton = _driver.FindElement(By.XPath("//input[@value='Create']"));
            submitButton.Click();

            // Verifica que la página rediriga a la lista de estudiantes
            Assert.Contains("/Estudiante", _driver.Url);
            TakeScreenshot("StudentRegistred");

            // Verifica que el nuevo estudiante aparece en la lista
            var studentRow = _driver.FindElement(By.XPath("//table/tbody/tr[last()]"));
            Assert.Contains("Ana", studentRow.Text);
            Assert.Contains("García", studentRow.Text);
            Assert.Contains("2024-0001", studentRow.Text);
            Assert.Contains("20/1/2024 00:00:00", studentRow.Text);
            Assert.Contains("001-23456789-0", studentRow.Text);
            Assert.Contains("F", studentRow.Text);
            Assert.Contains("S", studentRow.Text);
            _test.Pass("El estudiante fue registrado correctamente.");
        }
        [Fact]
        public void Test_RegisterNewProfesor()
        {
            _test = _extentReports.CreateTest("Test_RegisterNewProfesor")
                      .Info("Registrar un nuevo profesor.");

            // Navega a la página de "Crear nuevo profesor"
            _driver.Navigate().GoToUrl($"{_baseUrl}Profesor/Create");

            // Ingresa datos en el formulario
            _driver.FindElement(By.Id("Id")).SendKeys("9");
            _driver.FindElement(By.Id("Nombre")).SendKeys("Juanito");
            _driver.FindElement(By.Id("Apellido")).SendKeys("Pérez");
            _driver.FindElement(By.Id("fechaNacimiento")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("document.getElementById('fechaNacimiento').value = '1980-05-15T00:00';");
            _driver.FindElement(By.Id("Cedula")).SendKeys("1987654321");
            _driver.FindElement(By.Id("Sexo")).SendKeys("M");

            TakeScreenshot("ProfesorFilledData");
            // Hace clic en el botón de "Crear Profesor"
            var submitButton = _driver.FindElement(By.XPath("//input[@value='Create']"));
            submitButton.Click();

            // Verifica que la página rediriga a la lista de profesores
            Assert.Contains("/Profesor", _driver.Url);

            TakeScreenshot("ProfesorRegistred");

            // Verifica que el nuevo profesor aparece en la lista
            var professorRow = _driver.FindElement(By.XPath("//table/tbody/tr[last()]"));
            Assert.Contains("Juanito", professorRow.Text);
            Assert.Contains("Pérez", professorRow.Text);
            Assert.Contains("15/5/1980 00:00:00", professorRow.Text);
            Assert.Contains("1987654321", professorRow.Text);
            Assert.Contains("M", professorRow.Text);
            _test.Pass("El profesor fue registrado correctamente.");
            Dispose();
        }

        [Fact]
        public void Test_RegisterNewCarrera()
        {
            _test = _extentReports.CreateTest("Test_RegisterNewCarrera")
                      .Info("Registrar una nueva carrera.");

            // Navega a la página de "Crear nueva carrera"
            _driver.Navigate().GoToUrl($"{_baseUrl}Carrera/Create");

            // Ingresa datos en el formulario
            _driver.FindElement(By.Id("Codigo")).SendKeys("101");
            _driver.FindElement(By.Id("Nombre")).SendKeys("Ingeniería en Sistemas");
            _driver.FindElement(By.Id("Descripcion")).SendKeys("Carrera enfocada en el diseño y desarrollo de software.");
            _driver.FindElement(By.Id("Estado")).SendKeys("9"); 
            _driver.FindElement(By.Id("FechaCreacion")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("document.getElementById('FechaCreacion').value = '2024-11-20T00:00';");

            TakeScreenshot("CarreraFilledData");
            // Hace clic en el botón de "Crear Carrera"
            var submitButton = _driver.FindElement(By.XPath("//input[@value='Create']"));
            submitButton.Click();

            // Verifica que la página redirija a la lista de carreras
            Assert.Contains("/Carrera", _driver.Url);

            TakeScreenshot("CarreraRegistred");
            // Verifica que la nueva carrera aparece en la lista
            var carreraRow = _driver.FindElement(By.XPath("//table/tbody/tr[last()]"));
            Assert.Contains("101", carreraRow.Text);
            Assert.Contains("Ingeniería en Sistemas", carreraRow.Text);
            Assert.Contains("Carrera enfocada en el diseño y desarrollo de software.", carreraRow.Text);
            Assert.Contains("9", carreraRow.Text); 
            Assert.Contains("20/11/2024 00:00:00", carreraRow.Text);
            _test.Pass("La carrera fue registrada correctamente.");
            Dispose();
        }

        public void Dispose()
        {
            _driver.Quit();
            _extentReports.Flush(); 
        }
    }
}

using System;
using System.Web.Services;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.IO;
using System.Activities.Statements;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Web.Caching;

public partial class index : System.Web.UI.Page
{
    string language = String.Empty;
    string pass = String.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }

        getPass();
        getLanguage();
        getLanguageFab();
        getNavbar();
        getHeader();
        getAbout();
        getServices();
        getPortfolio();
        getPartners();
        getContacts();
        getPrivacyPolicy();
        getFooter();
    }

    private void getPass()
    {
        try
        {
            pass = Request.QueryString["pass"];

            if (!string.IsNullOrEmpty(pass))
            {
                if (pass != "KK77")
                {
                    pass = String.Empty;
                }
                else
                {
                    txtAuxBG.InnerHtml = "KK77.jpg";
                }
            }
        }
        catch (Exception e)
        {
            
        }
    }

    private void getLanguage()
    {
        try
        {
            language = Request.QueryString["language"];

            if (string.IsNullOrEmpty(language))
            {
                language = "PT";
            }
        }
        catch (Exception e)
        {
            language = "PT";
        }

        txtAuxLanguage.InnerHtml = language;
    }

    private void getLanguageFab()
    {
        var table = new StringBuilder();
        string imgFlag = string.Empty;
        string showHidePT = string.Empty;
        string showHideEN = string.Empty;
        string showHideFR = string.Empty;
        string showHideES = string.Empty;
        string showHideDE = string.Empty;

        switch (language)
        {
            case "ES":
                imgFlag = "icon_spain.png";
                showHideES = " class='d-none' ";
                break;
            case "FR":
                imgFlag = "icon_france.png";
                showHideFR = " class='d-none' ";
                break;
            case "EN":
                imgFlag = "icon_gb.png";
                showHideEN = " class='d-none' ";
                break;
            case "DE":
                imgFlag = "icon_germany.png";
                showHideDE = " class='d-none' ";
                break;
            case "PT":
            default:
                imgFlag = "icon_portugal.png";
                showHidePT = " class='d-none' ";
                break;
        }

        table.AppendFormat(@"   <div class='button iconbutton'>
                                    <img src='assets/img/{0}' class='icon' id='languageActive' onclick='openCloseLanguagesDialog();' />
                                    <ul class='options d-none' id='fabOptions'>
                                        <li id='languagePortuguese'{1} onclick='changeLanguagePage(351);'>
                                            <span class='btn-label'>{6}</span>
                                            <div class='iconbutton'>
                                                <img src='assets/img/icon_portugal.png' class='icon' />
                                            </div>
                                        </li>
                                        <li id='languageEnglish'{2} onclick='changeLanguagePage(44);'>
                                            <span class='btn-label'>{7}</span>
                                            <div class='iconbutton'>
                                                <img src='assets/img/icon_gb.png' class='icon' />
                                            </div>
                                        </li>
                                        <li id='languageFrench'{3} onclick='changeLanguagePage(33);'>
                                            <span class='btn-label'>{8}</span>
                                            <div class='iconbutton'>
                                                <img src='assets/img/icon_france.png' class='icon' />
                                            </div>
                                        </li>
                                        <li id='languageSpanish'{4} onclick='changeLanguagePage(34);'>
                                            <span class='btn-label'>{9}</span>
                                            <div class='iconbutton'>
                                                <img src='assets/img/icon_spain.png' class='icon' />
                                            </div>
                                        </li>
                                        <li id='languageGerman'{5} onclick='changeLanguagePage(49);'>
                                            <span class='btn-label'>{10}</span>
                                            <div class='iconbutton'>
                                                <img src='assets/img/icon_germany.png' class='icon' />
                                            </div>
                                        </li>
                                    </ul>
                                </div>", imgFlag, showHidePT, showHideEN, showHideFR, showHideES, showHideDE,
                                getTranslation("Português"), getTranslation("Inglês"), getTranslation("Francês"), getTranslation("Espanhol"), getTranslation("Alemão"));

        fabLanguage.InnerHtml = table.ToString();
    }

    private void getNavbar()
    {
        var table = new StringBuilder();

        table.AppendFormat(@"   <div class='container'>
                                    <a class='navbar-brand' href='#page-top'><img src='assets/img/logo.png' alt='André Afonso Lourenço' /></a>
                                    <button class='navbar-toggler' type='button' data-bs-toggle='collapse' data-bs-target='#navbarResponsive' aria-controls='navbarResponsive' aria-expanded='false' aria-label='Toggle navigation'>
                                        Menu
                                        <i class='fas fa-bars ms-1'></i>
                                    </button>
                                    <div class='collapse navbar-collapse' id='navbarResponsive'>
                                        <ul class='navbar-nav text-uppercase ms-auto py-4 py-lg-0'>
                                            <li class='nav-item'><a class='nav-link' href='#about'>{0}</a></li>
                                            <li class='nav-item'><a class='nav-link' href='#services'>{1}</a></li>
                                            <li class='nav-item'><a class='nav-link' href='#portfolio'>{2}</a></li>
                                            <li class='nav-item'><a class='nav-link' href='#team'>{3}</a></li>
                                            <li class='nav-item'><a class='nav-link' href='#contact'>{4}</a></li>
                                        </ul>
                                    </div>
                                </div>", getTranslation("Sobre Mim"), getTranslation("Áreas"), getTranslation("Portfolio"), getTranslation("Parceiros"), getTranslation("Contactos"));

        mainNav.InnerHtml = table.ToString();
    }

    private void getHeader()
    {
        var table = new StringBuilder();

        table.AppendFormat(@"   <div class='container'>
                                    <div class='masthead-heading text-uppercase'>André Afonso Lourenço</div>
                                    <div class='masthead-subheading'>{0}</div>
                                    <a class='btn btn-primary btn-xl text-uppercase' href='#about'>{1}</a>
                                </div>", getTranslation("Programador Android e Web"), getTranslation("Saiba Mais!"));

        header.InnerHtml = table.ToString();
    }

    private void getServices()
    {
        var table = new StringBuilder();

        table.AppendFormat(@"   <div class='container'>
                                    <div class='text-center'>
                                        <h2 class='section-heading text-uppercase'>{0}</h2>
                                        <h3 class='section-subheading text-muted'>{1}</h3>
                                    </div>
                                    <div class='row text-center'>
                                        <div class='col-xl-6 col-lg-6 col-md-12 col-sm-12'>
                                            <span class='fa-stack fa-4x'>
                                                <i class='fas fa-circle fa-stack-2x text-primary'></i>
                                                <i class='fas fa-mobile fa-stack-1x fa-inverse'></i>
                                            </span>
                                            <h4 class='my-3'>{2}</h4>
                                            <p class='text-muted'>{3}</p>
                                        </div>
                                        <div class='col-xl-6 col-lg-6 col-md-12 col-sm-12'>
                                            <span class='fa-stack fa-4x'>
                                                <i class='fas fa-circle fa-stack-2x text-primary'></i>
                                                <i class='fas fa-code fa-stack-1x fa-inverse'></i>
                                            </span>
                                            <h4 class='my-3'>{4}</h4>
                                            <p class='text-muted'>{5}</p>
                                        </div>
                                    </div>
                                </div>", getTranslation("Áreas"), getTranslation("Confira aqui as Áreas de Especialização!"),
                                getTranslation("Desenvolvimento Android"), getTranslation("Desenvolvimento de Aplicações Android (Java e Kotlin)"), 
                                getTranslation("Desenvolvimento Web"), getTranslation("Desenvolvimento de Softwares e WebSites em .NET (C#)"));

        services.InnerHtml = table.ToString();
    }

    private void getPortfolio()
    {
        var table = new StringBuilder();
        var table2 = new StringBuilder();

        table.AppendFormat(@"   <div class='container'>
                                    <div class='text-center'>
                                        <h2 class='section-heading text-uppercase'>{13}</h2>
                                        <h3 class='section-subheading text-muted'>{14}</h3>
                                    </div>
                                    <div class='row'>
                                        {0}{1}{2}{3}{4}{5}{6}{7}
                                    </div>
                                    <div class='text-center mt-4'>
                                        <h3 class='section-subheading text-muted'>{15}</h3>
                                    </div>
                                    <div class='row'>
                                        {8}{9}{10}{11}{12}
                                    </div>
                                </div>", 
                                getPortfolioLine("1"), getPortfolioLine("2"), getPortfolioLine("3"), getPortfolioLine("4"),
                                getPortfolioLine("5"), getPortfolioLine("6"), getPortfolioLine("7"), getPortfolioLine("8"),
                                getPortfolioLine("9"), getPortfolioLine("10"), getPortfolioLine("11"), getPortfolioLine("12"), getPortfolioLine("13"),
                                getTranslation("Portfolio"), getTranslation("WebSites e Softwares"), getTranslation("Aplicações Android"));

        table2.AppendFormat(@"  {0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}",
                                getPortfolioModal("1"), getPortfolioModal("2"), getPortfolioModal("3"), getPortfolioModal("4"), 
                                getPortfolioModal("5"), getPortfolioModal("6"), getPortfolioModal("7"), getPortfolioModal("8"), 
                                getPortfolioModal("9"), getPortfolioModal("10"), getPortfolioModal("11"), getPortfolioModal("12"), getPortfolioModal("13"));

        portfolio.InnerHtml = table.ToString();
        porfolioModals.InnerHtml = table2.ToString();
    }

    private string getPortfolioLine(string number)
    {
        string portfolioDefault = String.Format(@"  <div class='col-xl-6 col-lg-6 col-md-12 col-sm-12 mb-4 mb-sm-4'>
                                                        <!-- Portfolio item [NUMBER]-->
                                                        <div class='portfolio-item'>
                                                            <a class='portfolio-link' data-bs-toggle='modal' href='#portfolioModal[NUMBER]'>
                                                                <div class='portfolio-hover'>
                                                                    <div class='portfolio-hover-content'><i class='fas fa-plus fa-3x'></i></div>
                                                                </div>
                                                                <img class='img-fluid' src='assets/img/portfolio/[NUMBER].jpg' alt='[ALT]' />
                                                            </a>
                                                            <div class='portfolio-caption'>
                                                                <div class='portfolio-caption-heading'>[TITLE]</div>
                                                                <div class='portfolio-caption-subheading text-muted'>[SUBTITLE]</div>
                                                            </div>
                                                        </div>
                                                    </div>");

        switch(number)
        {
            case "1":
                return portfolioDefault.Replace("[NUMBER]", "1").Replace("[ALT]", "CliniCoimbra").Replace("[TITLE]", "CLINICOIMBRA.PT").Replace("[SUBTITLE]", getTranslation("WebSite"));
            case "2":
                return portfolioDefault.Replace("[NUMBER]", "2").Replace("[ALT]", "JPDado").Replace("[TITLE]", "JPDADO.PT").Replace("[SUBTITLE]", getTranslation("WebSite com Plataforma de Gestão de Conteúdos"));
            case "3":
                return portfolioDefault.Replace("[NUMBER]", "3").Replace("[ALT]", "Casa dos Bispos").Replace("[TITLE]", "CASADOSBISPOS.PT").Replace("[SUBTITLE]", getTranslation("WebSite com Plataforma de Gestão de Conteúdos"));
            case "4":
                return portfolioDefault.Replace("[NUMBER]", "4").Replace("[ALT]", "HappyBody").Replace("[TITLE]", "HAPPYBODY.SITE").Replace("[SUBTITLE]", getTranslation("WebSite com Plataforma de Gestão de Conteúdos"));
            case "5":
                return portfolioDefault.Replace("[NUMBER]", "5").Replace("[ALT]", "HappyBody").Replace("[TITLE]", "HAPPYBODY").Replace("[SUBTITLE]", getTranslation("Software de Gestão"));
            case "6":
                return portfolioDefault.Replace("[NUMBER]", "6").Replace("[ALT]", getTranslation("Gestão de Máquinas de Dinheiro")).Replace("[TITLE]", getTranslation("Gestão de Máquinas").ToUpper()).Replace("[SUBTITLE]", getTranslation("Software de Gestão"));
            case "7":
                return portfolioDefault.Replace("[NUMBER]", "7").Replace("[ALT]", "Grilo Car Service").Replace("[TITLE]", "GRILO CAR SERVICE").Replace("[SUBTITLE]", getTranslation("Software de Gestão (Em desenvolvimento...)"));
            case "8":
                return portfolioDefault.Replace("[NUMBER]", "8").Replace("[ALT]", "A2S").Replace("[TITLE]", "A2S").Replace("[SUBTITLE]", getTranslation("Software de Gestão (Em desenvolvimento...)"));
            case "9":
                return portfolioDefault.Replace("[NUMBER]", "9").Replace("[ALT]", getTranslation("Logística")).Replace("[TITLE]", getTranslation("Logística").ToUpper()).Replace("[SUBTITLE]", getTranslation("App Android"));
            case "10":
                return portfolioDefault.Replace("[NUMBER]", "10").Replace("[ALT]", getTranslation("Logística e Operação de Campo")).Replace("[TITLE]", getTranslation("Logística e Operação de Campo").ToUpper()).Replace("[SUBTITLE]", getTranslation("App Android"));
            case "11":
                return portfolioDefault.Replace("[NUMBER]", "11").Replace("[ALT]", getTranslation("Gestão de Vendas")).Replace("[TITLE]", getTranslation("Gestão de Vendas").ToUpper()).Replace("[SUBTITLE]", getTranslation("App Android"));
            case "12":
                return portfolioDefault.Replace("[NUMBER]", "12").Replace("[ALT]", getTranslation("Gestão de Armazém")).Replace("[TITLE]", getTranslation("Gestão de Armazém").ToUpper()).Replace("[SUBTITLE]", getTranslation("App Android e Modelação 3D"));
            case "13":
                return portfolioDefault.Replace("[NUMBER]", "13").Replace("[ALT]", getTranslation("Gestão de Serviços e Equipamentos")).Replace("[TITLE]", getTranslation("Gestão de Serviços e Equipamentos").ToUpper()).Replace("[SUBTITLE]", getTranslation("App Android"));
            default:
                return String.Empty;
        }
    }

    private string getPortfolioModal(string number)
    {
        string portfolioModalDefault = String.Format(@" <!-- Portfolio item [NUMBER] modal popup-->
                                                        <div class='portfolio-modal modal fade' id='portfolioModal[NUMBER]' tabindex='-1' role='dialog' aria-hidden='true'>
                                                            <div class='modal-dialog'>
                                                                <div class='modal-content'>
                                                                    <div class='close-modal' data-bs-dismiss='modal'><img src='assets/img/close-icon.svg' alt='Close modal' /></div>
                                                                    <div class='container'>
                                                                        <div class='row justify-content-center'>
                                                                            <div class='col-xl-8 col-lg-8 col-md-8 col-sm-8'>
                                                                                <div class='modal-body'>
                                                                                    <!-- Project details-->
                                                                                    <h2 class='text-uppercase'>[TITLE]</h2>
                                                                                    <p class='item-intro text-muted'>[SUBTITLE]</p>
                                                                                    <img class='img-fluid d-block mx-auto' src='assets/img/portfolio/[IMG].jpg' alt='[ALT]' />
                                                                                    <p>[DESCRIPTION]</p>
                                                                                    <ul class='list-inline'>
                                                                                        <li>
                                                                                            <strong>Cliente:</strong>
                                                                                            [CUSTOMER]
                                                                                        </li>
                                                                                        <li>
                                                                                            <strong>Categoria:</strong>
                                                                                            [CATEGORY]
                                                                                        </li>
                                                                                    </ul>
                                                                                    <button class='btn btn-primary btn-xl text-uppercase' data-bs-dismiss='modal' type='button'>
                                                                                        <i class='fas fa-times me-1'></i>
                                                                                        {0}
                                                                                    </button>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>", getTranslation("Fechar"));

        string website = getTranslation("WebSite");
        string webComPlat = getTranslation("WebSite com Plataforma de Gestão de Conteúdos");
        string swGestao = getTranslation("Software de Gestão");
        string swGestaoDev = getTranslation("Software de Gestão (Em desenvolvimento...)");
        string appAndroid = getTranslation("App Android");
        string appAndroid3D = getTranslation("App Android e Modelação 3D");
        string webProg = getTranslation("Programação Web");
        string onePageHTML = getTranslation("WebSite One Page em HTML com envio de emails em PHP");
        string aspnet = getTranslation("ASP.NET (C#), Base de Dados SQL Server e Programação Web");
        string webonepage = getTranslation("WebSite One Page em ASP.NET (C#) com recurso a Base de Dados em SQL Server e Web Pages gerido através de Software construído na mesma base.");
        string web = getTranslation("WebSite em ASP.NET (C#) com recurso a Base de Dados em SQL Server e Web Pages gerido através de Software construído na mesma base.");
        string swDesc = getTranslation("Realização de Software de Gestão em ASP.NET (C#) com recurso a Base de Dados em SQL Server e Web Pages.");
        string gestMaqDinh = getTranslation("Gestão de Máquinas de Dinheiro");
        string gestMaq = getTranslation("Gestão de Máquinas");
        string naoDivulgado = getTranslation("Não Divulgado");
        string logistic = getTranslation("Logística");
        string appAndroidDB = getTranslation("App Android (Java) com manutenção de Bases de Dados SQLite e postgreSQL");
        string descAppAndroidLogistic = getTranslation("Criação e Manutenção de Apps Android relacionadas com todo o processo de uma empresa de Logística (Carregamento de viaturas, entrega de encomendas...)");
        string logisticOpCampo = getTranslation("Logística e Operação de Campo");
        string empTCBrasil = getTranslation("Empresa de Telecomunicações Brasileira");
        string appAndroidWebView = getTranslation("Android (Java e Páginas ASP.NET (C#) Incorporadas em WebViews) e WebServices SOAP em ASP.NET (C#)");
        string appAndroidWebViewDesc = "Criação e Manutenção de Apps Android e WebServices SOAP relacionados com a Gestão de Armazém, Gestão de Transportes e trabalho de campo para uma empresa de telecomunicações brasileira.";
        string gestVendas = getTranslation("Gestão de Vendas");
        string varios = getTranslation("Vários");
        string androidWSSOAP = getTranslation("Android (Java) e WebServices SOAP em ASP.NET (C#)");
        string gestVendasDesc = getTranslation("Criação e Manutenção de Apps Android e WebServices SOAP relacionados com a Gestão de Vendas em ligação com Software de Faturação para várias empresas (maioritariamente do ramo da Distribuição Alimentar).");
        string gestArm = getTranslation("Gestão de Armazém");
        string gestArmDesc = getTranslation("Criação e Manutenção de Apps Android, WebServices SOAP e Modelação 3D relacionados com a Gestão de Armazém de uma empresa de congelados nacional.");
        string gestArmCust = getTranslation("Empresa de Congelados Nacional");
        string gestArmCat = getTranslation("Android (Java), WebServices SOAP em ASP.NET (C#) e Modelação 3D em Babylon.js incoporado em páginas ASP.NET (C#)");
        string gestServEquip = getTranslation("Gestão de Serviços e Equipamentos");
        string gestServEquipDesc = getTranslation("Criação e Manutenção de Apps Android e WebServices SOAP relacionados com a Gestão de Equipamentos e Gestão de Serviços para empresas de vários setores.");

        string alt = string.Empty;
        string title = string.Empty;
        string subtitle = string.Empty;
        string img = string.Empty;
        string customer = string.Empty;
        string category = string.Empty;
        string description = string.Empty;

        switch (number)
        {
            case "1":
                alt = "CliniCoimbra";
                title = "<a href='https://clinicoimbra.pt' target='_blank'>CLINICOIMBRA.PT</a>";
                subtitle = website;
                img = "clinicoimbra";
                customer = "CliniCoimbra";
                category = aspnet;
                description = webonepage;
                break;
            case "2":
                alt = "JPDado";
                title = "<a href='http://jpdado.pt' target='_blank'>JPDADO.PT</a>";
                subtitle = webComPlat;
                img = "jpdado";
                customer = "JPDado";
                category = webProg;
                description = onePageHTML;
                break;
            case "3":
                alt = "Casa dos Bispos";
                title = "<a href='https://casadosbispos.pt' target='_blank'>CASADOSBISPOS.PT</a>";
                subtitle = webComPlat;
                img = "casadosbispos";
                customer = "Casa dos Bispos";
                category = aspnet;
                description = webonepage;
                break;
            case "4":
                alt = "HappyBody";
                title = "<a href='https://happybody.site' target='_blank'>HAPPYBODY.SITE</a>";
                subtitle = webComPlat;
                img = "happybody";
                customer = "HappyBody";
                category = aspnet;
                description = web;
                break;
            case "5":
                alt = "HappyBody";
                title = "HAPPYBODY";
                subtitle = swGestao;
                img = "happybodysoftware";
                customer = "HappyBody";
                category = aspnet;
                description = swDesc;
                break;
            case "6":
                alt = gestMaqDinh;
                title = gestMaq.ToUpper();
                subtitle = swGestao;
                img = number;
                customer = naoDivulgado;
                category = aspnet;
                description = swDesc;
                break;
            case "7":
                alt = "Grilo Car Service";
                title = "GRILO CAR SERVICE";
                subtitle = swGestaoDev;
                img = "grilocarservice_software";
                customer = "Grilo Car Service";
                category = aspnet;
                description = swDesc;
                break;
            case "8":
                alt = "A2S";
                title = "A2S";
                subtitle = swGestaoDev;
                img = "a2s";
                customer = "A2S";
                category = aspnet;
                description = swDesc;
                break;
            case "9":
                alt = logistic;
                title = logistic.ToUpper();
                subtitle = appAndroid;
                img = number;
                customer = "GLS IT Services";
                category = appAndroidDB;
                description = descAppAndroidLogistic;
                break;
            case "10":
                alt = logisticOpCampo;
                title = logisticOpCampo.ToUpper();
                subtitle = appAndroid;
                img = number;
                customer = empTCBrasil;
                category = appAndroidWebView;
                description = appAndroidWebViewDesc;
                break;
            case "11":
                alt = gestVendas;
                title = gestVendas.ToUpper();
                subtitle = appAndroid;
                img = number;
                customer = varios;
                category = androidWSSOAP;
                description = gestVendasDesc;
                break;
            case "12":
                alt = gestArm;
                title = gestArm.ToUpper();
                subtitle = appAndroid3D;
                img = number;
                customer = gestArmCust;
                category = gestArmCat;
                description = gestArmDesc;
                break;
            case "13":
                alt = gestServEquip;
                title = gestServEquip.ToUpper();
                subtitle = appAndroid;
                img = number;
                customer = varios;
                category = androidWSSOAP;
                description = swDesc;
                break;
            default:
                break;
        }

        return portfolioModalDefault.Replace("[NUMBER]", number).Replace("[ALT]", alt).Replace("[TITLE]", title).Replace("[SUBTITLE]", subtitle)
            .Replace("[IMG]", img).Replace("[CUSTOMER]", customer).Replace("[CATEGORY]", category).Replace("[DESCRIPTION]", description);
    }

    private void getAbout()
    {
        var table = new StringBuilder();

        table.AppendFormat(@"   <div class='container'>
                                    <div class='text-center'>
                                        <h2 class='section-heading text-uppercase'>{0}</h2>
                                        <h2 class='section-subheading text-muted'>{1}</h2>
                                    </div>
                                    <ul class='timeline'>
                                        <li class='timeline-inverted'>
                                            <div class='timeline-image'><img class='rounded-circle img-fluid' src='assets/img/about/gls.png' alt='GLS' /></div>
                                            <div class='timeline-panel'>
                                                <div class='timeline-heading'>
                                                    <h4>{2}</h4>
                                                    <h4 class='subheading'>GLS IT Services Portugal</h4>
                                                    <h5>Venda do Pinheiro, Portugal</h5>
                                                </div>
                                                <div class='timeline-body'>
                                                    <p class='text-muted'>
                                                        {3}<br />{4}<br />{5}
                                                    </p>
                                                </div>
                                            </div>
                                        </li>
                                        <li>
                                            <div class='timeline-image'><img class='rounded-circle img-fluid' src='assets/img/about/coimbra.png' alt='Bettertech' /></div>
                                            <div class='timeline-panel'>
                                                <div class='timeline-heading'>
                                                    <h4>{6}</h4>
                                                    <h4 class='subheading'>{7}</h4>
                                                    <h5>Santarém, Portugal</h5>
                                                </div>
                                                <div class='timeline-body'>
                                                    <p class='text-muted'>
                                                        {8}<br />{9}<br />{10}<br />{11}
                                                    </p>
                                                </div>
                                            </div>
                                        </li>
                                        <li>
                                            <div class='timeline-image'><img class='rounded-circle img-fluid' src='assets/img/about/coimbra.png' alt='Bettertech' /></div>
                                            <div class='timeline-panel'>
                                                <div class='timeline-heading'>
                                                    <h4>{6}</h4>
                                                    <h4 class='subheading'>{7}</h4>
                                                    <h5>Coimbra, Portugal</h5>
                                                </div>
                                                <div class='timeline-body'>
                                                    <p class='text-muted'>
                                                        {8}<br />{9}<br />{10}<br />{11}
                                                    </p>
                                                </div>
                                            </div>
                                        </li>
                                        <li class='timeline-inverted'>
                                            <div class='timeline-image'><img class='rounded-circle img-fluid' src='assets/img/about/usp.png' alt='UBI' /></div>
                                            <div class='timeline-panel'>
                                                <div class='timeline-heading'>
                                                    <h4>{12}</h4>
                                                    <h4 class='subheading'>{13}</h4>
                                                    <h5>Pinhel, Portugal</h5>
                                                </div>
                                                <div class='timeline-body'>
                                                    <p class='text-muted'>
                                                        {14}
                                                    </p>
                                                </div>
                                            </div>
                                        </li>
                                        <li>
                                            <div class='timeline-image'><img class='rounded-circle img-fluid' src='assets/img/about/ubi.png' alt='UBI' /></div>
                                            <div class='timeline-panel'>
                                                <div class='timeline-heading'>
                                                    <h4>{15}</h4>
                                                    <h4 class='subheading'>{16}</h4>
                                                    <h5>Covilhã, Portugal</h5>
                                                </div>
                                                <div class='timeline-body'>
                                                    <p class='text-muted'>
                                                        {17}
                                                    </p>
                                                </div>
                                            </div>
                                        </li>
                                        <li class='timeline-inverted'>
                                            <div class='timeline-image'><img class='rounded-circle img-fluid' src='assets/img/about/fct.png' alt='FCT-UNL' /></div>
                                            <div class='timeline-panel'>
                                                <div class='timeline-heading'>
                                                    <h4>{18}</h4>
                                                    <h4 class='subheading'>{19}</h4>
                                                    <h5>Almada, Portugal</h5>
                                                </div>
                                                <div class='timeline-body'>
                                                    <p class='text-muted'>
                                                        {20}
                                                    </p>
                                                </div>
                                            </div>
                                        </li>
                                        <li class='timeline-inverted'>
                                            <div class='timeline-image'>
                                                <h4>{21}</h4>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                                
                                <div class='container mt-4' class='text-align: center'>
                                    <div class='row align-items-center' class='text-align: center'>
                                        <h2 class='section-subheading text-muted'>{22}</h2>
                                        <h3 class='section-subheading text-muted'>{23}</h3>
                                    </div>
                                    <div class='row align-items-center'>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            {22}
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            {24}
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            {25}
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            {26}
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            {27}
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            {28}
                                        </div>
                                    </div>
                                    <div class='row align-items-center'>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            <img class='img-fluid img-brand d-block mx-auto' src='assets/img/icon_gb.png' style='max-width: 100%; height: auto;' alt='Inglês' />
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            B2
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            B2
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            B2
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            B2
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            B2
                                        </div>
                                    </div>
                                    <div class='row align-items-center'>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            <img class='img-fluid img-brand d-block mx-auto' src='assets/img/icon_france.png' style='max-width: 100%; height: auto;' alt='Inglês' />
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            B1
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            B1
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            A2
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            A2
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            A2
                                        </div>
                                    </div>
                                    <div class='row align-items-center'>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            <img class='img-fluid img-brand d-block mx-auto' src='assets/img/icon_spain.png' style='max-width: 100%; height: auto;' alt='Inglês' />
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            A2
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            A2
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            A2
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            A2
                                        </div>
                                        <div class='col-xl-2 col-lg-2 col-md-2 col-sm-2 my-3'>
                                            A1
                                        </div>
                                    </div>
                                </div>
                                <div class='container mt-4' class='text-align: center'>
                                    <div class='row align-items-center' class='text-align: center'>
                                        <h2 class='section-subheading text-muted'>{29}</h2>
                                    </div>
                                    <div class='row align-items-center'>
                                        <div class='col-xl-12 col-lg-12 col-md-12 col-sm-12 my-3'>
                                            {30}
                                        </div>
                                        <div class='col-xl-12 col-lg-12 col-md-12 col-sm-12 my-3'>
                                            {31}
                                        </div>
                                    </div>
                                </div>
                                <div class='container mt-4' class='text-align: center'>
                                    <div class='row align-items-center' class='text-align: center'>
                                        <h2 class='section-subheading text-muted'>{32}</h2>
                                    </div>
                                    <div class='row align-items-center'>
                                        <div class='col-xl-6 col-lg-6 col-md-6 col-sm-6 my-3'>
                                            {33}<br />{34}<br />{35}
                                        </div>
                                        <div class='col-xl-6 col-lg-6 col-md-6 col-sm-6 my-3'>
                                            {36}<br />{37}<br />{38}
                                        </div>
                                    </div>
                                </div>", getTranslation("Sobre Mim"), getTranslation("Percurso Pessoal e Profissional"),
                                getTranslation("Setembro 2018 - Novembro 2024"), getTranslation("Mobile Developer (Android)"),
                                getTranslation("Construção e manutenção de Aplicações Android"), 
                                getTranslation("Apoio em Design Aplicacional e Manutenção de Bases de Dados em postgreSQL e SQLite"),
                                getTranslation("Fevereiro 2015 - Agosto 2018"),
                                getTranslation("Bettertech - Análise e Implementação de Sistemas Informáticos Lda"),
                                getTranslation("Modelação 3D de Armazéns para Sistema de Gestão Logística"),
                                getTranslation("Mobile Developer (Android) e ASP.NET"), getTranslation("Construção e manutenção de Aplicações Android"),
                                getTranslation("Construção e manutenção de WebServices SOAP para consumo das aplicações Android"),
                                getTranslation("Setembro 2011 - Junho 2012"), getTranslation("Universidade Sénior de Pinhel"),
                                getTranslation("Professor Voluntário de Informática"), getTranslation("Setembro 2010 - Março 2014"),
                                getTranslation("Universidade da Beira Interior"), getTranslation("Licenciatura em Engenharia Informática"),
                                getTranslation("Setembro 2008 - Setembro 2010"), getTranslation("Faculdade de Ciências e Tecnologias - Universidade Nova de Lisboa"),
                                getTranslation("Frequência no Mestrado Integrado em Engenharia Eletrotécnica e de Computadores"),
                                getTranslation("4<br />Junho<br />1990"), getTranslation("Línguas"),
                                getTranslation("Língua Materna: Português"), getTranslation("Compreensão Oral"),
                                getTranslation("Leitura"), getTranslation("Interação Oral"),
                                getTranslation("Produção Oral"), getTranslation("Escrita"),
                                getTranslation("Skills Profissionais"),
                                getTranslation("Web Development (HTML, CSS, JavaScript, jQuery); Java; C; C++; ASP.NET (C#); Android (Java); postgreSQL; SQLite; MySQL; SQL Server"),
                                getTranslation("Android Studio; IntelliJ; Microsoft Visual Studio; Microsoft Office; Adobe Photoshop; Adobe Illustrator; DBeaver; SSMS; Microsoft Teams; Jenkins; JIRA; Bitbucket; Confluence;"),
                                getTranslation("Formação Complementar"), getTranslation("Certificado de Competências Pedagógicas"),
                                getTranslation("Conclusão - Estudos e Formação, Guarda (Portugal)"), getTranslation("Certificado nº F614838/2013"),
                                getTranslation("Certificação Cisco CCNA Exploration"), getTranslation("Network Fundamentals - Módulo I"),
                                getTranslation("Academia Cisco, CFIUTE, Covilhã (Portugal)"));

        about.InnerHtml = table.ToString();
    }

    private string getIcons(string type, string url)
    {
        string site = "<a class='btn btn-dark btn-social mx-2' href='[URL]' target='_blank'><i class='fas fa-globe'></i></a>";
        string facebook = "<a class='btn btn-dark btn-social mx-2' href='https://www.facebook.com/[URL]' target='_blank'><i class='fab fa-facebook-f'></i></a>";
        string instagram = "<a class='btn btn-dark btn-social mx-2' href='https://www.instagram.com/[URL]' target='_blank'><i class='fab fa-instagram'></i></a>";
        string linkedin = "<a class='btn btn-dark btn-social mx-2' href='https://www.linkedin.com/[URL]' target='_blank'><i class='fab fa-linkedin-in'></i></a>";
        string email = "<a class='btn btn-dark btn-social mx-2' href='mailto:[URL]' target='_blank'><i class='fas fa-envelope'></i></a>";
        string phone = "<a class='btn btn-dark btn-social mx-2' href='tel:[URL]' target='_blank'><i class='fas fa-mobile'></i></a>";
        string youtube = "<a class='btn btn-dark btn-social mx-2' href='https://www.youtube.com/channel/[URL]' target='_blank'><i class='fab fa-youtube'></i></a>";

        switch(type)
        {
            case "SITE":
                return site.Replace("[URL]", url);
            case "FB":
                return facebook.Replace("[URL]", url);
            case "IG":
                return instagram.Replace("[URL]", url);
            case "LINKEDIN":
                return linkedin.Replace("[URL]", url);
            case "EMAIL":
                return email.Replace("[URL]", url);
            case "PHONE":
                return phone.Replace("[URL]", url);
            case "YT":
                return youtube.Replace("[URL]", url);
            default:
                return String.Empty;
        }
    }

    private string getPartnerInfo(string img, string title, string subtitle)
    {
        return String.Format(@" <img class='mx-auto rounded-circle' src='assets/img/team/{0}' alt='{1}' />
                                <h4>{1}</h4>
                                <p class='text-muted'>{2}</p>", img, getTranslation(title), getTranslation(subtitle));
    }

    private void getPartners()
    {
        var table = new StringBuilder();

        table.AppendFormat(@"   <div class='container'>
                                    <div class='text-center'>
                                        <h2 class='section-heading text-uppercase'>Parceiros e Clientes</h2>
                                    </div>
                                    <div class='row'>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {55}{0}{1}{2}{3}
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {56}{4}
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {57}{5}{6}{7}{8}
                                            </div>
                                        </div>
                                    </div>
                                    <div class='row'>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {58}{9}{10}{11}{12}
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {59}{13}{14}{15}{16}{17}{18}{19}{20}
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {74}{77}{75}{76}
                                            </div>
                                        </div>
                                    </div>
                                    <div class='row'>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {60}{72}{73}{21}{22}{23}
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {61}{24}{25}{26}{27}{28}
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {62}{29}{30}
                                            </div>
                                        </div>
                                    </div>
                                    <div class='row'>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {63}{31}
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {64}{32}{33}{34}{35}
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {65}{36}{37}{38}
                                            </div>
                                        </div>
                                    </div>
                                    <div class='row'>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {66}{39}{40}{41}{42}
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {67}{43}{44}
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {68}{45}{46}
                                            </div>
                                        </div>
                                    </div>
                                    <div class='row'>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {69}{47}{48}
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {70}{49}{50}
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-12 col-sm-12'>
                                            <div class='team-member'>
                                                {71}{51}{52}{53}{54}
                                            </div>
                                        </div>
                                    </div>
                                    <!--<div class='row'>
                                        <div class='col-lg-8 mx-auto text-center'><p class='large text-muted'>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aut eaque, laboriosam veritatis, quos non quis ad perspiciatis, totam corporis ea, alias ut unde.</p></div>
                                    </div>-->
                                </div>", getIcons("SITE", "https://a2s.pt/"),
                                getIcons("FB", "profile.php?id=100069629808738&fref=ts"),
                                getIcons("EMAIL", "geral@a2s.pt"),
                                getIcons("PHONE", "+351261025007"),
                                getIcons("SITE", "https://casadosbispos.pt/"),
                                getIcons("SITE", "https://clinicoimbra.pt/"),
                                getIcons("EMAIL", "clinicoimbra@gmail.com"),
                                getIcons("PHONE", "+351239481325"),
                                getIcons("PHONE", "+351239481326"),
                                getIcons("FB", "grilocarservice/"),
                                getIcons("IG", "grilocarservice/"),
                                getIcons("EMAIL", "grilocarservice22@gmail.com"),
                                getIcons("PHONE", "+351917043976"),
                                getIcons("SITE", "https://happybody.site/"),
                                getIcons("FB", "HappyBodyPersonalTrainerSoniaRusso/"),
                                getIcons("IG", "happybodyptsoniarusso/"),
                                getIcons("LINKEDIN", "in/happybodys%C3%B3niarusso-linkdin/"),
                                getIcons("YT", "UCDSISyx3jztdW4JbnQXaD1A/"),
                                getIcons("EMAIL", "happybodyfitcoach@gmail.com"),
                                getIcons("PHONE", "+41774468932"),
                                getIcons("PHONE", "+351914457108"),
                                getIcons("FB", "herbalifenutritionoeste/"),
                                getIcons("IG", "herbalifenutritionoeste/"),
                                getIcons("EMAIL", "herbalifenutritionoeste@gmail.com"),
                                getIcons("SITE", "https://www.jf-muxagata.pt/"),
                                getIcons("FB", "muxagata.fornosdealgodres/"),
                                getIcons("IG", "fag_muxagata/"),
                                getIcons("EMAIL", "fmuxagatafag@hotmail.com"),
                                getIcons("PHONE", "+351271789838"),
                                getIcons("SITE", "http://jpdado.pt/"),
                                getIcons("EMAIL", "geral@jpdado.pt"),
                                getIcons("SITE", "https://hiqnet.pt/"),
                                getIcons("FB", "profile.php?id=100089393545114/"),
                                getIcons("IG", "jorge_agostinho_producoes/"),
                                getIcons("EMAIL", "ja_producoes@outlook.pt"),
                                getIcons("PHONE", "+351926493289"),
                                getIcons("SITE", "https://www.iadportugal.pt/consultor-imobiliario/loide.oliveira"),
                                getIcons("EMAIL", "loide.oliveira@creditocomigo.pt"),
                                getIcons("PHONE", "+351914830665"),
                                getIcons("FB", "profile.php?id=100029115137548/"),
                                getIcons("IG", "rabiscodivertido_grafica/"),
                                getIcons("EMAIL", "rabiscodivertido.geral@hotmail.com"),
                                getIcons("PHONE", "+351969244846"),
                                getIcons("EMAIL", "raquel.neves@belaseguros.com"),
                                getIcons("PHONE", "+351968713203"),
                                getIcons("IG", "rito.creative/"),
                                getIcons("EMAIL", "rito.creative.pt@gmail.com"),
                                getIcons("IG", "sandrapaulos.psicologa/"),
                                getIcons("EMAIL", "sandrapaulos@gmail.com"),
                                getIcons("FB", "ThomasMartinsOsteoFitCoach/"),
                                getIcons("IG", "thomasmartinsosteofitcoach/"),
                                getIcons("FB", "profile.php?id=100029115137548/"),
                                getIcons("IG", "rabiscodivertido_grafica/"),
                                getIcons("EMAIL", "thomas_pereiro@hotmail.com"),
                                getIcons("PHONE", "+351912443905"),
                                getPartnerInfo("a2s.png", "A2S", "Associação para o Desenvolvimento Sustentável da Região Saloia"),
                                getPartnerInfo("casadosbispos.png", "Casa dos Bispos", "Turismo Rural"),
                                getPartnerInfo("clinicoimbra.png", "CliniCoimbra", "Consultórios Médicos"),
                                getPartnerInfo("grilocarservice.png", "Grilo Car Service", "Oficina Auto"),
                                getPartnerInfo("hb.png", "HappyBody", "Personal Trainer"),
                                getPartnerInfo("herbalife_oeste.png", "Herbalife Nutrition Oeste - Distribuidor Independente", "Distribuidor de Produtos Herbalife Nutrition"),
                                getPartnerInfo("jfmuxagata.png", "JF Muxagata", "Junta de Freguesia da Muxagata (Fornos de Algodres, Portugal)"),
                                getPartnerInfo("jpdado.png", "JPDADO", "Serviços de Engenharia e Consultadoria"),
                                getPartnerInfo("hiqnet.png", "HIQNET", "Soluções de Domótica, Eletricidade, WiFi e Redes Empresariais"),
                                getPartnerInfo("jorgeagostinho.png", "Jorge Agostinho", "Fotografia, Vídeo e Publicidade"),
                                getPartnerInfo("loideoliveira.png", "Loide Oliveira", "Intermediária de Crédito <i>Crédito Comigo</i> e Consultora Imobiliária <i>IAD</i>"),
                                getPartnerInfo("rabiscodivertido.png", "Rabisco Divertido", "Publicidade e Artes Gráficas"),
                                getPartnerInfo("raquelneves.png", "Raquel Neves - Bela Seguros", "Mediadora de Seguros Ramo Vida e Não Vida <i>Bela Seguros</i>"),
                                getPartnerInfo("ard.png", "Rito Creative", "Creative | Design | Logo | Merchandising | Publicidade | Photo"),
                                getPartnerInfo("sandrapaulos.png", "Sandra Paulos", "Psicóloga Clínica e Formadora"),
                                getPartnerInfo("sunshine_babyshop.png", "Sunshine Baby Shop", "Artigos para Bebés e Crianças"),
                                getPartnerInfo("thomasmartins.png", "Thomas Martins", "Osteo & Fit Coach"),
                                getIcons("SITE", "https://catiagrilo.goherbalife.com/"),
                                getIcons("SITE", "https://andreafonsolourenco.goherbalife.com/"),
                                getPartnerInfo("cgtravel.png", "CGTravel", "CGTravel"),
                                getIcons("IG", "cgtravel90/"),
                                getIcons("EMAIL", "cgtravel90@gmail.com"),
                                getIcons("SITE", "https://www.andreafonsolourenco.pt/CGTravel/website/index.aspx"));

        team.InnerHtml = table.ToString();
    }

    private void getContacts()
    {
        var table = new StringBuilder();

        table.AppendFormat(@"   <div class='container'>
                                    <div class='text-center'>
                                        <h2 class='section-heading text-uppercase'>{0}</h2>
                                        <!--<h3 class='section-subheading text-muted'>Lorem ipsum dolor sit amet consectetur.</h3>-->
                                    </div>
                                    <div class='row align-items-center'>
                                        <div class='col-xl-4 col-lg-4 col-md-4 col-sm-4 my-3 text-center'>
                                            <div style='width: 100% !important; height: auto !important;' id='divIconEmail'>
                                                <a href='#!'>
                                                    <img class='img-fluid img-brand d-block mx-auto' src='assets/img/icon_email_white.png' alt='Email' />
                                                </a>
                                            </div>
                                            <div style='width: 100% !important; height: auto !important;' class='text-white mt-2' id='divInfoEmail'>
                                                geral@andreafonsolourenco.pt
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-4 col-sm-4 my-3 text-center'>
                                            <div style='width: 100% !important; height: auto !important;' id='divIconPhone'>
                                                <a href='#!'>
                                                    <img class='img-fluid img-brand d-block mx-auto' src='assets/img/icon_phone_white.png' alt='Telefone' />
                                                </a>
                                            </div>
                                            <div style='width: 100% !important; height: auto !important;' class='text-white mt-2' id='divInfoPhone'>
                                                (+351) 912 803 666<br />
                                                {15}
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-4 col-sm-4 my-3 text-center'>
                                            <div style='width: 100% !important; height: auto !important;' id='divIconAddress'>
                                                <a href='#!'>
                                                    <img class='img-fluid img-brand d-block mx-auto' src='assets/img/icon_address_white.png' alt='Morada Principal' />
                                                </a>
                                            </div>
                                            <div style='width: 100% !important; height: auto !important;' class='text-white mt-2' id='divInfoAddress'>
                                                {12}<br />
                                                2040-406 Vale de Óbidos (Rio Maior, Portugal)
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-4 col-sm-4 my-3 text-center'>
                                            <div style='width: 100% !important; height: auto !important;' id='divIconSecEmail'>
                                                <a href='#!'>
                                                    <img class='img-fluid img-brand d-block mx-auto' src='assets/img/icon_email_white.png' alt='Email' />
                                                </a>
                                            </div>
                                            <div style='width: 100% !important; height: auto !important;' class='text-white mt-2' id='divInfoSecEmail'>
                                                afonsopereira6@gmail.com
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-4 col-sm-4 my-3 text-center'>
                                            <div style='width: 100% !important; height: auto !important;' id='divIconSecAddress'>
                                                <a href='#!'>
                                                    <img class='img-fluid img-brand d-block mx-auto' src='assets/img/icon_secondary_address_white.png' alt='Moradas Secundárias' />
                                                </a>
                                            </div>
                                            <div style='width: 100% !important; height: auto !important;' class='text-white mt-2' id='divInfoSecAddress'>
                                                {14}<br />
                                                3000-232 Coimbra (Portugal)<br /><br />
                                            </div>
                                        </div>
                                        <div class='col-xl-4 col-lg-4 col-md-4 col-sm-4 my-3 text-center'>
                                            <div style='width: 100% !important; height: auto !important;' id='divIconSecAddress2'>
                                                <a href='#!'>
                                                    <img class='img-fluid img-brand d-block mx-auto' src='assets/img/icon_secondary_address_white.png' alt='Moradas Secundárias' />
                                                </a>
                                            </div>
                                            <div style='width: 100% !important; height: auto !important;' class='text-white mt-2' id='divInfoSecAddress2'>
                                                {13}<br />
                                                6400-415 Pinhel (Portugal)
                                            </div>
                                        </div>
                                    </div>

                                    <div id='contactForm'>
                                        <div class='row align-items-stretch mb-5'>
                                            <div class='col-md-6' id='divFormNameEmailSubject'>
                                                <div class='form-group'>
                                                    <!-- Name input-->
                                                    <input class='form-control' id='name' type='text' placeholder='{1}' />
                                                    <div class='invalid-feedback' id='invalidName'>{2}</div>
                                                </div>
                                                <div class='form-group mt-4'>
                                                    <!-- Email address input-->
                                                    <input class='form-control' id='email' type='email' placeholder='{3}' />
                                                    <div class='invalid-feedback' id='invalidEmail'>{4}</div>
                                                </div>
                                                <div class='form-group mb-md-0 mt-4'>
                                                    <!-- Phone number input-->
                                                    <input class='form-control' id='subject' type='text' placeholder='{5}' />
                                                    <div class='invalid-feedback' id='invalidSubject'>{6}</div>
                                                </div>
                                            </div>
                                            <div class='col-md-6' id='divFormMessage'>
                                                <div class='form-group form-group-textarea mb-md-0'>
                                                    <!-- Message input-->
                                                    <textarea class='form-control' id='message' placeholder='{7}' style='height: 100% !important;'></textarea>
                                                    <div class='invalid-feedback' id='invalidMessage'>{8}</div>
                                                </div>
                                            </div>
                                        </div>
                    
                                        <div class='d-none' id='submitSuccessMessage'>
                                            <div class='text-center text-white mb-3'>
                                                <div class='fw-bolder'>{9}</div>
                                            </div>
                                        </div>

                                        <div class='d-none' id='submitErrorMessage'>
                                            <div class='text-center text-danger mb-3'>{10}</div>
                                        </div>

                                        <!-- Submit Button-->
                                        <div class='text-center'>
                                            <input class='btn btn-primary btn-xl text-uppercase' type='button' id='submitButton' onclick='sendEmail();' value='{11}' />
                                        </div>
                                    </div>
                                </div>", getTranslation("Contactos"), getTranslation("Nome"), getTranslation("Por favor, insira um nome válido!"), 
                                getTranslation("Email"), getTranslation("Por favor, insira um email válido!"),
                                getTranslation("Assunto"), getTranslation("Por favor, insira um assunto válido!"), 
                                getTranslation("Mensagem"), getTranslation("Por favor, insira uma mensagem válida!"), 
                                getTranslation("Email enviado com sucesso!"), getTranslation("Ocorreu um erro ao enviar o email! Por favor, tente novamente!"),
                                getTranslation("Enviar!"), getTranslation("Largo da Ermida, 14, 1"), getTranslation("Rua de Moçambique, 40"),
                                getTranslation("Rua José Alberto dos Reis, 122, 4º Esq"), getTranslation("Custo de uma chamada para a rede móvel nacional (Portugal)"));

        contact.InnerHtml = table.ToString();
    }

    private void getPrivacyPolicy()
    {
        string text = string.Empty;

        switch(language)
        {
            case "EN":
                text = String.Format(@" Your privacy is important to us. It is the policy of https://www.andreafonsolourenco.pt to respect your privacy regarding any information we may collect from you.<br />
                                        You will only be asked for personal information (Name and Email) on the contact form present on the site under the ""Contact"" tab.
                                        We do this with your knowledge and consent and it will only be used to respond to your contact.<br />
                                        The requested information will only be kept for as long as necessary to provide the requested contact.
                                        We will not share this same information publicly or with third parties except as required by law.<br />
                                        Our site contains links to external sites that are not operated by us.
                                        Please be aware that we have no control over the content and practices of those sites and cannot accept responsibility for their privacy policies.<br />
                                        You are free to decline our request for information, with the understanding that you will not be able to contact us via the contact form on the site if you do not provide us with this information.<br />
                                        Your continued use of our site will be deemed acceptance of our practices around privacy and personal information.
                                        If you have any questions about how we handle user data and personal information, please contact us.<br /><br />
                                        <b>User's Undertaking</b><br />
                                        The user undertakes to make appropriate use of the content and information that https://www.andreafonsolourenco.pt offers on the website and with enunciative but not limitative character:<br />
                                        a) Not to engage in activities that are illegal or contrary to good faith and public order;<br />
                                        b) Not to spread propaganda or content of a racist, xenophobic nature, any type of illegal pornography, apology for terrorism or against human rights;<br />
                                        c) Not to cause damage to physical (hardware) and logical (software) systems of the site, its supplier or third parties, to introduce or propagate computer viruses or any other hardware or software systems that are capable of causing the aforementioned damage.<br /><br />
                                        <b>Further Information</b><br />
                                        For more information, you can contact us through the contacts present on the site.");
                break;
            case "FR":
                text = String.Format(@" Votre vie privée est importante pour nous. La politique de https://www.andreafonsolourenco.pt est de respecter votre vie privée en ce qui concerne les informations que nous pouvons recueillir auprès de vous.<br />
                                        Il ne vous sera demandé des informations personnelles (nom et adresse électronique) que sur le formulaire de contact présent sur le site sous l'onglet ""Contact"". 
                                        Nous le faisons en toute connaissance de cause et avec votre consentement, et ces informations ne seront utilisées que pour répondre à votre demande.<br />
                                        Les informations demandées ne seront conservées que le temps nécessaire pour répondre à la demande de contact. Nous ne partagerons pas ces mêmes informations avec le public ou des tiers, sauf si la loi l'exige.<br />
                                        Notre site contient des liens vers des sites web externes qui ne sont pas exploités par nous. 
                                        Sachez que nous n'avons aucun contrôle sur le contenu et les pratiques de ces sites et que nous ne pouvons être tenus responsables de leur politique en matière de protection de la vie privée.<br />
                                        Vous êtes libre de refuser notre demande d'informations, étant entendu que vous ne pourrez pas nous contacter via le formulaire de contact du site si vous ne nous fournissez pas ces informations.<br />
                                        Si vous continuez à utiliser notre site, vous serez réputé avoir accepté nos pratiques en matière de protection de la vie privée et des informations personnelles.
                                        Si vous avez des questions sur la manière dont nous traitons les données des utilisateurs et les informations personnelles, veuillez nous contacter.<br /><br />
                                        <b>Engagement de l'utilisateur</b><br />
                                        L'utilisateur s'engage à faire un usage approprié du contenu et des informations que https://www.andreafonsolourenco.pt propose sur le site web et à caractère énonciatif mais non limitatif:<br />
                                        a) Ne pas se livrer à des activités illégales ou contraires à la bonne foi et à l'ordre public;<br />
                                        b) Ne pas diffuser de propagande ou de contenu à caractère raciste, xénophobe, tout type de pornographie illégale, d'apologie du terrorisme ou contre les droits de l'homme;<br />
                                        c) Ne pas causer de dommages aux systèmes physiques (hardware) et logiques (software) du site, de son fournisseur ou de tiers, introduire ou propager des virus informatiques ou tout autre système hardware ou software capable de causer les dommages susmentionnés.<br /><br />
                                        <b>Informations complémentaires</b><br />
                                        Pour de plus amples informations, vous pouvez nous contacter par le biais des contacts présents sur le site web.");
                break;
            case "ES":
                text = String.Format(@" Su privacidad es importante para nosotros. La política de https://www.andreafonsolourenco.pt es respetar su privacidad con respecto a cualquier información que podamos recopilar de usted.<br />
                                        Sólo se le pedirá información personal (nombre y dirección de correo electrónico) en el formulario de contacto presente en el sitio, en la pestaña ""Contacto"".
                                        Lo hacemos con su conocimiento y consentimiento y sólo se utilizará para responder a su contacto.<br />
                                        La información solicitada sólo se conservará el tiempo necesario para proporcionar el contacto solicitado. No compartiremos esta misma información públicamente ni con terceros, excepto cuando lo exija la ley.<br />
                                        Nuestro sitio contiene enlaces a sitios web externos que no son operados por nosotros.
                                        Por favor, tenga en cuenta que no tenemos control sobre el contenido y las prácticas de esos sitios y no podemos aceptar responsabilidad por sus políticas de privacidad.<br />
                                        Usted es libre de rechazar nuestra solicitud de información, entendiendo que no podrá ponerse en contacto con nosotros a través del formulario de contacto del sitio si no nos facilita esta información.<br />
                                        Su uso continuado de nuestro sitio se considerará una aceptación de nuestras prácticas en materia de privacidad e información personal.
                                        Si tiene alguna pregunta sobre cómo tratamos los datos del usuario y la información personal, póngase en contacto con nosotros.<br /><br />
                                        <b>Compromiso del usuario</b><br />
                                        El usuario se compromete a hacer un uso adecuado de los contenidos e informaciones que https://www.andreafonsolourenco.pt ofrece en el sitio web y con carácter enunciativo pero no limitativo a:<br />
                                        a) No realizar actividades ilícitas o contrarias a la buena fe y al orden público;<br />
                                        b) No difundir propaganda o contenidos de carácter racista, xenófobo, pornografía ilegal de cualquier tipo, apología del terrorismo o atentatorio contra los derechos humanos;<br />
                                        c) No provocar daños en los sistemas físicos (hardware) y lógicos (software) del sitio, de su proveedor o de terceras personas, introducir o difundir en la red virus informáticos o cualesquiera otros sistemas físicos o lógicos que sean susceptibles de provocar los daños anteriormente mencionados.<br /><br />
                                        <b>Para más información</b><br />
                                        Para más información, puede ponerse en contacto con nosotros a través de los contactos presentes en el sitio web.");
                break;
            case "DE":
                text = String.Format(@" Ihre Privatsphäre ist uns wichtig. https://www.andreafonsolourenco.pt respektiert Ihre Privatsphäre in Bezug auf alle Informationen, die wir von Ihnen sammeln.<br />
                                        Persönliche Daten (Name und E-Mail) werden nur über das Kontaktformular auf der Website unter der Registerkarte ""Kontakt"" abgefragt.
                                        Wir tun dies mit Ihrem Wissen und Ihrer Zustimmung, und die Daten werden nur verwendet, um auf Ihre Anfrage zu antworten.<br />
                                        Die angeforderten Informationen werden nur so lange aufbewahrt, wie es für die Kontaktaufnahme erforderlich ist. Wir geben diese Informationen nicht an die Öffentlichkeit oder an Dritte weiter, es sei denn, dies ist gesetzlich vorgeschrieben.<br />
                                        Unsere Website enthält Links zu externen Websites, die nicht von uns betrieben werden.
                                        Bitte beachten Sie, dass wir keine Kontrolle über den Inhalt und die Praktiken dieser Websites haben und keine Verantwortung für deren Datenschutzrichtlinien übernehmen können.<br />
                                        Es steht Ihnen frei, unser Ersuchen um Informationen abzulehnen, allerdings können Sie uns dann nicht mehr über das Kontaktformular auf der Website kontaktieren, wenn Sie uns diese Informationen nicht zur Verfügung stellen.<br />
                                        Wenn Sie unsere Website weiterhin nutzen, gehen wir davon aus, dass Sie unsere Praktiken in Bezug auf Datenschutz und persönliche Daten akzeptieren. 
                                        Wenn Sie Fragen dazu haben, wie wir mit Benutzerdaten und persönlichen Informationen umgehen, wenden Sie sich bitte an uns.<br /><br />
                                        <b>Verpflichtung des Benutzers</b><br />
                                        Der Nutzer verpflichtet sich, die Inhalte und Informationen, die https://www.andreafonsolourenco.pt auf der Website anbietet, in angemessener Weise zu nutzen, und zwar mit ausdrücklichem, aber nicht einschränkendem Charakter:<br />
                                        a) sich nicht an Aktivitäten zu beteiligen, die illegal sind oder gegen den guten Glauben und die öffentliche Ordnung verstoßen;<br />
                                        b) keine Propaganda oder Inhalte rassistischer oder fremdenfeindlicher Natur, keine illegale Pornographie, keine Entschuldigung für Terrorismus oder gegen die Menschenrechte zu verbreiten<br />
                                        c) keine Schäden an den physischen (Hardware) und logischen (Software) Systemen der Website, ihrer Lieferanten oder Dritter zu verursachen, keine Computerviren oder andere Hardware- oder Softwaresysteme einzuführen oder zu verbreiten, die in der Lage sind, die vorgenannten Schäden zu verursachen.<br /><br />
                                        <b>Weitere Auskünfte</b><br />
                                        Für weitere Informationen können Sie uns über die auf der Website angegebenen Kontakte kontaktieren.");
                break;
            case "PT":
            default:
                text = String.Format(@" A sua privacidade é importante para nós. É política do site https://www.andreafonsolourenco.pt respeitar a sua privacidade em relação a qualquer informação sua que possamos recolher.<br />
                                        Apenas serão solicitadas informações pessoais (Nome e Email) no formulário de contacto presente no site no separador “Contactos”. 
                                        Fazemo-lo com o seu conhecimento e consentimento e apenas será usado para responder ao seu contacto.<br />
                                        A informação solicitada apenas será guardada durante o tempo necessário para fornecer o contacto solicitado. 
                                        Não iremos compartilhar essas mesmas informações publicamente ou com terceiros, exceto quando exigido por lei.<br />
                                        O nosso site contém links para sites externos que não são operados por nós. 
                                        Esteja ciente de que não temos controlo sobre o conteúdo e práticas desses sites e não podemos aceitar responsabilidade por suas respetivas políticas de privacidade.<br />
                                        O utilizador é livre para recusar a nossa solicitação de informações, entendendo que não poderá entrar em contacto connosco através do formulário de contacto presente no site se não nos fornecer essa mesma informação.<br />
                                        O uso continuado de nosso site será considerado como aceitação de nossas práticas em torno de privacidade e informações pessoais. Se você tiver alguma dúvida sobre como lidamos com dados do usuário e informações pessoais, entre em contacto connosco.<br /><br />
                                        <b>Compromisso do Utilizador</b><br />
                                        O utilizador compromete-se a fazer uso adequado dos conteúdos e da informação que o site https://www.andreafonsolourenco.pt oferece no site e com caráter enunciativo, mas não limitativo:<br />
                                        a) Não se envolver em atividades que ilegais ou contrárias à boa fé a à ordem pública;<br />
                                        b) Não difundir propaganda ou conteúdo de natureza racista, xenófoba, qualquer tipo de pornografia ilegal, de apologia ao terrorismo ou contra os direitos humanos;<br />
                                        c) Não causar danos aos sistemas físicos (hardwares) e lógicos (softwares) do site, do seu fornecedor ou de terceiros, para introduzir ou propagar vírus informáticos ou quaisquer outros sistemas de hardware ou software que sejam capazes de causar danos anteriormente mencionados.<br /><br />
                                        <b>Mais informações</b><br />
                                        Para mais informações, poderá entrar em contacto connosco através dos contactos presentes no site.");
                break;
        }

        string table = String.Format(@" <div class='portfolio-modal modal' id='dialogPrivacyPolicy'>
                                            <div class='modal-dialog'>
                                                <div class='modal-content'>
                                                    <div class='close-modal'><img src='assets/img/close-icon.svg' alt='Close modal' onclick='closePrivacyPolicy();' /></div>
                                                    <div class='container'>
                                                        <div class='row justify-content-center'>
                                                            <div class='col-xl-12 col-lg-12 col-md-12 col-sm-12'>
                                                                <div class='modal-body'>
                                                                    <h2 class='text-uppercase'>{1}</h2>
                                                                    <p style='text-align: justify !important;'>{2}</p>
                                                                    <button class='btn btn-primary btn-xl text-uppercase' type='button' onclick='closePrivacyPolicy();'>
                                                                        <i class='fas fa-times me-1'></i>
                                                                        {0}
                                                                    </button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>", getTranslation("Fechar"), getTranslation("Política de Privacidade"), text);

        privacyPolicy.InnerHtml = table;
    }

    private void getFooter()
    {
        var table = new StringBuilder();

        table.AppendFormat(@"   <div class='container'>
                                    <div class='row align-items-center'>
                                        <div class='col-lg-3 text-lg-start'>Copyright &copy; andreafonsolourenco.pt 2023</div>
                                        <div class='col-lg-3 text-lg-start'>Template by <a href='https://themewagon.com/'>Themewagon</a></div>
                                        <div class='col-lg-3 my-3 my-lg-0'>
                                            <a class='btn btn-dark btn-social mx-2' href='https://www.facebook.com/ocneruolosnfaerdna'><i class='fab fa-facebook-f'></i></a>
                                            <a class='btn btn-dark btn-social mx-2' href='https://www.instagram.com/andreafonsolourenco/'><i class='fab fa-instagram'></i></a>
                                        </div>
                                        <div class='col-lg-3 text-lg-end'>
                                            <a class='link-dark text-decoration-none me-3' href='#!' onclick='openPrivacyPolicy();'>{0}</a>
                                        </div>
                                    </div>
                                </div>", getTranslation("Política de Privacidade"));

        footer.InnerHtml = table.ToString();
    }

    [WebMethod]
    public static string getRetornoURL(string url)
    {
        try
        {
            WebClient client = new WebClient();

            client.Headers.Add("User-Agent: BrowseAndDownload");
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            string ret = client.DownloadString(url);

            //TRIMA a string        
            ret = ret.Trim();

            return ret;
        }
        catch (Exception)
        {
            return "";
        }
    }

    [WebMethod]
    public static string sendEmailFromTemplate(string assunto, string nome, string email, string body, string language)
    {
        var table = new StringBuilder();
        DataSqlServer oDB = new DataSqlServer();
        string sendEmail = "geral@andreafonsolourenco.pt", sendEmailPwd = "CFMGALice7722KK", sendEmailSTMP = "mail.andreafonsolourenco.pt", sendEmailSMTPPort = "465", sendEmailEmailsAlerta = "geral@andreafonsolourenco.pt;afonsopereira6@gmail.com";
        string customerEmailTitle = string.Empty;
        string customerEmailBody = string.Empty;

        switch(language)
        {
            case "EN":
                customerEmailTitle = "Contact Email from the site www.andreafonsolourenco.pt<br />" + assunto;
                customerEmailBody = "Thank you for your message! We will try to respond as soon as possible. Thank you!<br /><br />";
                break;
            case "FR":
                customerEmailTitle = "Contact par courriel via le site web www.andreafonsolourenco.pt<br />" + assunto;
                customerEmailBody = "Merci pour votre message! Nous nous efforcerons de vous répondre dans les meilleurs délais. Nous nous efforcerons de vous répondre dans les plus brefs délais.<br /><br />";
                break;
            case "ES":
                customerEmailTitle = "Contacto por correo electrónico a través del sitio web www.andreafonsolourenco.pt<br />" + assunto;
                customerEmailBody = "¡Gracias por su mensaje! Intentaremos responderle lo antes posible. ¡Muchas gracias!<br /><br />";
                break;
            case "DE":
                customerEmailTitle = "E-Mail-Kontakt über die Website<br />" + assunto;
                customerEmailBody = "Vielen Dank für Ihre Nachricht! Wir werden versuchen, so schnell wie möglich zu antworten. Wir danken Ihnen!<br /><br />";
                break;
            case "PT":
            default:
                customerEmailTitle = "Email de Contacto através do site www.andreafonsolourenco.pt<br />" + assunto;
                customerEmailBody = "Obrigado pelo seu contacto! Tentaremos responder com a maior brevidade possível. Obrigado!<br /><br />";
                break;
        }

        try
        {
            MailMessage mailMessage = new MailMessage();
            string emailBody = "";

            string newsletterText = string.Empty;
            newsletterText = File.ReadAllText(HttpContext.Current.Server.MapPath("~") + "\\templates\\template_email.html");

            emailBody += "Nome: " + nome + "<br />";
            emailBody += "Email: " + email + "<br />";
            emailBody += body.Replace("\n", "<br />") + "<br /><br />";
            emailBody += "Responder em " + language + "<br /><br />";

            // ------------------------------------
            // Processa o template 
            // ------------------------------------
            newsletterText = newsletterText.Replace("[EMAIL_INTRO]", "Email de Contacto através do site www.andreafonsolourenco.pt<br />" + assunto);
            newsletterText = newsletterText.Replace("[EMAIL_TEXTBODY]", emailBody);
            newsletterText = newsletterText.Replace("[SUBJECT]", assunto);


            // ------------------------------------
            mailMessage.From = new MailAddress(sendEmail, "ANDRÉ AFONSO LOURENÇO");

            int x = 0;

            foreach (var word in sendEmailEmailsAlerta.Split(';'))
            {
                if (x == 0)
                {
                    mailMessage.To.Add(word);
                }
                else
                {
                    mailMessage.Bcc.Add(word);
                }
                x++;
            }

            mailMessage.Subject = assunto;
            mailMessage.Body = newsletterText;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.Normal;

            string html = "html";

            mailMessage.SubjectEncoding = Encoding.UTF8;
            mailMessage.BodyEncoding = Encoding.UTF8;

            SmtpClient smtpClient = new SmtpClient(sendEmailSTMP);
            NetworkCredential mailAuthentication = new NetworkCredential(sendEmail, sendEmailPwd);

            smtpClient.EnableSsl = false;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = mailAuthentication;
            smtpClient.Timeout = 50000;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtpClient.Send(mailMessage);
            smtpClient.Dispose();

            newsletterText = string.Empty;
            newsletterText = File.ReadAllText(HttpContext.Current.Server.MapPath("~") + "\\templates\\template_email.html");

            emailBody = string.Empty;
            emailBody += customerEmailBody + nome + "<br />" + email + "<br />" + body.Replace("\n", "<br />") + "<br /><br />";
            newsletterText = newsletterText.Replace("[EMAIL_INTRO]", customerEmailTitle);
            newsletterText = newsletterText.Replace("[EMAIL_TEXTBODY]", emailBody);
            newsletterText = newsletterText.Replace("[SUBJECT]", assunto);

            mailMessage.From = new MailAddress(sendEmail, "ANDRÉ AFONSO LOURENÇO");

            mailMessage.To.Add(email);

            foreach (var word in sendEmailEmailsAlerta.Split(';'))
            {
                mailMessage.Bcc.Add(word);
            }

            mailMessage.Subject = assunto;
            mailMessage.Body = newsletterText;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.Normal;

            mailMessage.SubjectEncoding = Encoding.UTF8;
            mailMessage.BodyEncoding = Encoding.UTF8;

            smtpClient = new SmtpClient(sendEmailSTMP);
            mailAuthentication = new NetworkCredential(sendEmail, sendEmailPwd);

            //smtpClient.Port = Convert.ToInt32(_smtpport);
            smtpClient.EnableSsl = false;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = mailAuthentication;
            smtpClient.Timeout = 50000;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtpClient.Send(mailMessage);
            smtpClient.Dispose();

            return "1";
        }
        catch (Exception ex)
        {
            return "-1";
        }
    }

    private string getTranslation(string word)
    {
        switch(language)
        {
            case "EN":
                return getTranslationEN(word);
            case "FR":
                return getTranslationFR(word);
            case "ES":
                return getTranslationES(word);
            case "DE":
                return getTranslationDE(word);
            case "PT":
            default:
                return word;
        }
    }

    private string getTranslationEN(string word)
    {
        switch (word)
        {
            case "Sobre Mim":
                return "About Me";
            case "Áreas":
                return "Areas";
            case "Portfolio":
                return "Portfolio";
            case "Parceiros":
                return "Partners";
            case "Contactos":
                return "Contacts";
            case "Português":
                return "Portuguese";
            case "Francês":
                return "French";
            case "Inglês":
                return "English";
            case "Espanhol":
                return "Spanish";
            case "Alemão":
                return "German";
            case "Programador Android e Web":
                return "Android and Web Developer";
            case "Saiba Mais!":
                return "Know More!";
            case "Confira aqui as Áreas de Especialização!":
                return "Check out our Areas of Expertise here!";
            case "Desenvolvimento Android":
                return "Android Development";
            case "Desenvolvimento de Aplicações nativas em Android":
                return "Native Android Application Development";
            case "Desenvolvimento Web":
                return "Web Development";
            case "Desenvolvimento de Softwares e WebSites em ASP.NET(C#), com possibilidade de incorporar soluções 3D":
                return "Software and Web Site Development in ASP.NET(C#), with the possibility of incorporating 3D solutions";
            case "WebSite":
                return "WebSite";
            case "WebSite com Plataforma de Gestão de Conteúdos":
                return "WebSite with Content Management Platform";
            case "Software de Gestão":
                return "Management Software";
            case "Gestão de Máquinas":
                return "Machine Management";
            case "Gestão de Máquinas de Dinheiro":
                return "Cash Machine Management";
            case "Software de Gestão (Em desenvolvimento...)":
                return "Management Software (under development...)";
            case "Logística":
                return "Logístics";
            case "App Android":
                return "Android App";
            case "Logística e Operação de Campo":
                return "Logistics and Field Operation";
            case "App Android e Modelação 3D":
                return "Android App and 3D Modeling";
            case "Gestão de Vendas":
                return "Sales Management";
            case "Gestão de Armazém":
                return "Warehouse Management";
            case "Gestão de Serviços e Equipamentos":
                return "Services and Equipments Management";
            case "Programação Web":
                return "Web Programming";
            case "WebSite One Page em HTML com envio de emails em PHP":
                return "HTML One Page WebSite with PHP mailings";
            case "ASP.NET (C#), Base de Dados SQL Server e Programação Web":
                return "ASP.NET (C#), SQL Server Database and Web Programming";
            case "WebSite One Page em ASP.NET (C#) com recurso a Base de Dados em SQL Server e Web Pages gerido através de Software construído na mesma base.":
                return "One Page WebSite in ASP.NET (C#) with resource to SQL Server database and Web Pages managed through Software built on the same database.";
            case "WebSite em ASP.NET (C#) com recurso a Base de Dados em SQL Server e Web Pages gerido através de Software construído na mesma base.":
                return "WebSite in ASP.NET (C#) using SQL Server database and Web Pages managed through software built in the same base.";
            case "Realização de Software de Gestão em ASP.NET (C#) com recurso a Base de Dados em SQL Server e Web Pages.":
                return "Realization of Management Software in ASP.NET (C#) using SQL Server Database and Web Pages.";
            case "Não Divulgado":
                return "Not disclosed";
            case "App Android (Java) com manutenção de Bases de Dados SQLite e postgreSQL":
                return "Android App (Java) with SQLite and postgreSQL Database maintenance";
            case "Criação e Manutenção de Apps Android relacionadas com todo o processo de uma empresa de Logística (Carregamento de viaturas, entrega de encomendas...)":
                return "Creation and Maintenance of Android Apps related with the whole process of a Logistics company (loading cars, delivering packages...)";
            case "Empresa de Telecomunicações Brasileira":
                return "Brazilian Telecommunications Company";
            case "Android (Java e Páginas ASP.NET (C#) Incorporadas em WebViews) e WebServices SOAP em ASP.NET (C#)":
                return "Android (Java and ASP.NET (C#) Pages Embedded in WebViews) and SOAP WebServices in ASP.NET (C#)";
            case "Criação e Manutenção de Apps Android e WebServices SOAP relacionados com a Gestão de Armazém, Gestão de Transportes e trabalho de campo para uma empresa de telecomunicações brasileira.":
                return "Creation and Maintenance of Android Apps and SOAP WebServices related to Warehouse Management, Transportation Management and field work for a Brazilian telecommunications company.";
            case "Vários":
                return "Various";
            case "Android (Java) e WebServices SOAP em ASP.NET (C#)":
                return "Android (Java) and SOAP WebServices in ASP.NET (C#)";
            case "Criação e Manutenção de Apps Android e WebServices SOAP relacionados com a Gestão de Vendas em ligação com Software de Faturação para várias empresas (maioritariamente do ramo da Distribuição Alimentar).":
                return "Creation and Maintenance of Android Apps and SOAP WebServices related to Sales Management in connection with Invoicing Software for several companies (mostly from the Food Distribution industry).";
            case "Criação e Manutenção de Apps Android, WebServices SOAP e Modelação 3D relacionados com a Gestão de Armazém de uma empresa de congelados nacional.":
                return "Creation and Maintenance of Android Apps, SOAP WebServices and 3D Modeling related to Warehouse Management for a national frozen food company.";
            case "Empresa de Congelados Nacional":
                return "Portuguese Frozen Food Company";
            case "Android (Java), WebServices SOAP em ASP.NET (C#) e Modelação 3D em Babylon.js incoporado em páginas ASP.NET (C#)":
                return "Android (Java), SOAP WebServices in ASP.NET (C#) and 3D Modeling in Babylon.js embedded in ASP.NET (C#) pages";
            case "Criação e Manutenção de Apps Android e WebServices SOAP relacionados com a Gestão de Equipamentos e Gestão de Serviços para empresas de vários setores.":
                return "Creation and Maintenance of Android Apps and SOAP WebServices related to Equipment Management and Service Management for companies in various industries.";
            case "Fechar":
                return "Close";
            case "WebSites e Softwares":
                return "WebSites and Softwares";
            case "Aplicações Android":
                return "Android Applications";
            case "Percurso Pessoal e Profissional":
                return "Personal and Professional Background";
            case "Desde Setembro 2018":
                return "Since September 2018";
            case "Mobile Developer (Android)":
                return "Mobile Developer (Android)";
            case "Construção e manutenção de Aplicações Android":
                return "Building and maintaining Android Applications";
            case "Apoio em Design Aplicacional e Manutenção de Bases de Dados em postgreSQL e SQLite":
                return "Support in Application Design and Database Maintenance in postgreSQL and SQLite";
            case "Fevereiro 2015 - Agosto 2018":
                return "February 2015 - August 2018";
            case "Bettertech - Análise e Implementação de Sistemas Informáticos Lda":
                return "Bettertech - Analysis and Implementation of Computer Systems Ltd.";
            case "Modelação 3D de Armazéns para Sistema de Gestão Logística":
                return "3D Warehouse Modeling for Logistics Management System";
            case "Mobile Developer (Android) e ASP.NET":
                return "Mobile Developer (Android) and ASP.NET";
            case "Construção e manutenção de WebServices SOAP para consumo das aplicações Android":
                return "Building and maintaining SOAP WebServices for consumption of Android applications";
            case "Setembro 2011 - Junho 2012":
                return "September 2011 - June 2012";
            case "Universidade Sénior de Pinhel":
                return "Senior University of Pinhel";
            case "Professor Voluntário de Informática":
                return "Voluntary Professor of Informatics"; 
            case "Setembro 2010 - Março 2014":
                return "September 2010 - March 2014";
            case "Universidade da Beira Interior":
                return "University of Beira Interior";
            case "Licenciatura em Engenharia Informática":
                return "Degree in Computer Engineering";
            case "Setembro 2008 - Setembro 2010":
                return "September 2008 - September 2010"; 
            case "Faculdade de Ciências e Tecnologias - Universidade Nova de Lisboa":
                return "Faculty of Sciences and Technologies - New University of Lisbon";
            case "Frequência no Mestrado Integrado em Engenharia Eletrotécnica e de Computadores":
                return "Frequency in the Integrated Master in Electrical and Computer Engineering";
            case "4<br />Junho<br />1990":
                return "4th<br />June<br />1990"; 
            case "Línguas":
                return "Languages";
            case "Língua Materna: Português":
                return "Mother Language: Portuguese"; 
            case "Compreensão Oral":
                return "Listening Comprehension";
            case "Leitura":
                return "Reading"; 
            case "Interação Oral":
                return "Oral Interaction";
            case "Produção Oral":
                return "Spoken Production"; 
            case "Escrita":
                return "Writing";
            case "Skills Profissionais":
                return "Professional Skills";
            case "Web Development (HTML, CSS, JavaScript, jQuery); Java; C; C++; ASP.NET (C#); Android (Java); postgreSQL; SQLite; MySQL; SQL Server":
                return "Web Development (HTML, CSS, JavaScript, jQuery); Java; C; C++; ASP.NET (C#); Android (Java); postgreSQL; SQLite; MySQL; SQL Server";
            case "Android Studio; IntelliJ; Microsoft Visual Studio; Microsoft Office; Adobe Photoshop; Adobe Illustrator; DBeaver; SSMS; Microsoft Teams; Jenkins; JIRA; Bitbucket; Confluence;":
                return "Android Studio; IntelliJ; Microsoft Visual Studio; Microsoft Office; Adobe Photoshop; Adobe Illustrator; DBeaver; SSMS; Microsoft Teams; Jenkins; JIRA; Bitbucket; Confluence;";
            case "Formação Complementar":
                return "Complementary Training"; 
            case "Certificado de Competências Pedagógicas":
                return "Certificate of Pedagogical Skills";
            case "Conclusão - Estudos e Formação, Guarda (Portugal)":
                return "Conclusão - Studies and Training, Guarda (Portugal)"; 
            case "Certificado nº F614838/2013":
                return "Certificate nº F614838/2013";
            case "Certificação Cisco CCNA Exploration":
                return "Cisco CCNA Exploration Certification"; 
            case "Network Fundamentals - Módulo I":
                return "Network Fundamentals - Module I";
            case "Academia Cisco, CFIUTE, Covilhã (Portugal)":
                return "Cisco Academy, CFIUTE, Covilhã (Portugal)";
            case "Nome":
                return "Name";
            case "Por favor, insira um nome válido!":
                return "Please enter a valid name!";
            case "Email":
                return "Email";
            case "Por favor, insira um email válido!":
                return "Please enter a valid email address!";
            case "Assunto":
                return "Subject";
            case "Por favor, insira um assunto válido!":
                return "Please enter a valid subject!";
            case "Mensagem":
                return "Message";
            case "Por favor, insira uma mensagem válida!":
                return "Please enter a valid message!";
            case "Email enviado com sucesso!":
                return "Email sent successfully!";
            case "Ocorreu um erro ao enviar o email! Por favor, tente novamente!":
                return "An error occurred while sending the email! Please try again!";
            case "Enviar!":
                return "Send!";
            case "Política de Privacidade":
                return "Privacy Policy";
            case "Associação para o Desenvolvimento Sustentável da Região Saloia":
                return "Association for the Sustainable Development of the Saloia Region";
            case "Turismo Rural":
                return "Rural Tourism";
            case "Consultórios Médicos":
                return "Medical Offices";
            case "Oficina Auto":
                return "Auto Workshop";
            case "Personal Trainer":
                return "Personal Trainer";
            case "Herbalife Nutrition Oeste - Distribuidor Independente":
                return "Herbalife Nutrition Oeste - Independent Distributor";
            case "Distribuidor de Produtos Herbalife Nutrition":
                return "Distributor of Herbalife Nutrition Products";
            case "Junta de Freguesia da Muxagata (Fornos de Algodres, Portugal)":
                return "Muxagata Town Council (Fornos de Algodres, Portugal)";
            case "Serviços de Engenharia e Consultadoria":
                return "Engineering and Consulting Services";
            case "Soluções de Domótica, Eletricidade, WiFi e Redes Empresariais":
                return "Domotics, Electricity, WiFi and Enterprise Network Solutions";
            case "Fotografia, Vídeo e Publicidade":
                return "Photography, Video and Advertising";
            case "Intermediária de Crédito <i>Crédito Comigo</i> e Consultora Imobiliária <i>IAD</i>":
                return "Credit Intermediary for <i>Crédito Comigo</i> and Real Estate Consultant <i>IAD</i>";
            case "Publicidade e Artes Gráficas":
                return "Advertising and Graphic Arts";
            case "Mediadora de Seguros Ramo Vida e Não Vida Bela Seguros":
                return "Life and Non Life Insurance Intermediary Bela Seguros";
            case "Creative | Design | Logo | Merchandising | Publicidade | Photo":
                return "Creative | Design | Logo | Merchandising | Advertising | Photo";
            case "Psicóloga Clínica e Formadora":
                return "Clinical Psychologist and Trainer";
            case "Artigos para Bebés e Crianças":
                return "Articles for Babies and Children";
            case "Osteo & Fit Coach":
                return "Osteo & Fit Coach";
            case "Largo da Ermida, 14, 1":
                return "Square of the Ermida, 14, 1st floor";
            case "Rua de Moçambique, 40":
                return "Mozambique's Street, 40";
            case "Rua José Alberto dos Reis, 122, 4º Esq":
                return "José Alberto dos Reis' Street, 122, 4th Floor Left";
            case "Custo de uma chamada para a rede móvel nacional (Portugal)":
                return "Cost of a call to the national mobile network (Portugal)";
            default:
                return word;
        }
    }

    private string getTranslationFR(string word)
    {
        switch (word)
        {
            case "Sobre Mim":
                return "À propos de moi";
            case "Áreas":
                return "Domaines";
            case "Portfolio":
                return "Portefeuille";
            case "Parceiros":
                return "Partenaires";
            case "Contactos":
                return "Contacts";
            case "Português":
                return "Portugais";
            case "Francês":
                return "Français";
            case "Inglês":
                return "Anglais";
            case "Espanhol":
                return "Espagnol";
            case "Alemão":
                return "Allemand";
            case "Programador Android e Web":
                return "Développeur Android et Web";
            case "Saiba Mais!":
                return "En savoir plus!";
            case "Confira aqui as Áreas de Especialização!":
                return "Consultez ici nos domaines d'expertise!";
            case "Desenvolvimento Android":
                return "Développement Android";
            case "Desenvolvimento de Aplicações nativas em Android":
                return "Développement d'applications Android natives";
            case "Desenvolvimento Web":
                return "Développement Web";
            case "Desenvolvimento de Softwares e WebSites em ASP.NET(C#), com possibilidade de incorporar soluções 3D":
                return "Développement de logiciels et de sites web en ASP.NET(C#), avec la possibilité d'incorporer des solutions 3D";
            case "WebSite":
                return "Site Web";
            case "WebSite com Plataforma de Gestão de Conteúdos":
                return "Site Web avec Plateforme de Gestion de Contenu";
            case "Software de Gestão":
                return "Logiciel de Gestion";
            case "Gestão de Máquinas":
                return "Gestion des Machines";
            case "Gestão de Máquinas de Dinheiro":
                return "Gestion des distributeurs automatiques de billets";
            case "Software de Gestão (Em desenvolvimento...)":
                return "Logiciel de Gestion (en cours de développement...)";
            case "Logística":
                return "Logistique";
            case "App Android":
                return "Application Android";
            case "Logística e Operação de Campo":
                return "Logistique et Opérations sur le Terrain";
            case "App Android e Modelação 3D":
                return "Application Android em Modélisation 3D";
            case "Gestão de Vendas":
                return "Gestion des Ventes";
            case "Gestão de Armazém":
                return "Gestion d'Entrepôt";
            case "Gestão de Serviços e Equipamentos":
                return "Gestion des Services et des Équipements";
            case "Programação Web":
                return "Programmation Web";
            case "WebSite One Page em HTML com envio de emails em PHP":
                return "Site web HTML à une page avec mailings PHP";
            case "ASP.NET (C#), Base de Dados SQL Server e Programação Web":
                return "ASP.NET (C#), base de données SQL Server et programmation Web";
            case "WebSite One Page em ASP.NET (C#) com recurso a Base de Dados em SQL Server e Web Pages gerido através de Software construído na mesma base.":
                return "Site Web d'une page en ASP.NET (C#) avec une base de données SQL Server et des pages Web gérées par un logiciel construit dans la même base de données.";
            case "WebSite em ASP.NET (C#) com recurso a Base de Dados em SQL Server e Web Pages gerido através de Software construído na mesma base.":
                return "Site Web en ASP.NET (C#) avec une ressource pour la base de données SQL Server et des pages Web gérées par un logiciel construit dans la même base.";
            case "Realização de Software de Gestão em ASP.NET (C#) com recurso a Base de Dados em SQL Server e Web Pages.":
                return "Développement d'un logiciel de gestion en ASP.NET (C#) utilisant une base de données SQL Server et des pages Web.";
            case "Não Divulgado":
                return "Non divulgué";
            case "App Android (Java) com manutenção de Bases de Dados SQLite e postgreSQL":
                return "Application Android (Java) avec maintenance des bases de données SQLite et PostgreSQL";
            case "Criação e Manutenção de Apps Android relacionadas com todo o processo de uma empresa de Logística (Carregamento de viaturas, entrega de encomendas...)":
                return "Création et maintenance d'applications Android liées à tous les processus d'une société de logistique (chargement de voitures, livraison de colis...).";
            case "Empresa de Telecomunicações Brasileira":
                return "Société brésilienne de télécommunications";
            case "Android (Java e Páginas ASP.NET (C#) Incorporadas em WebViews) e WebServices SOAP em ASP.NET (C#)":
                return "Android (Java et ASP.NET (C#) Pages embarquées dans des WebViews) et WebServices SOAP en ASP.NET (C#)";
            case "Criação e Manutenção de Apps Android e WebServices SOAP relacionados com a Gestão de Armazém, Gestão de Transportes e trabalho de campo para uma empresa de telecomunicações brasileira.":
                return "Création et maintenance d'applications Android et de WebServices SOAP liés à la gestion d'entrepôts, à la gestion du transport et au travail sur le terrain pour une société de télécommunications brésilienne.";
            case "Vários":
                return "Diverses applications";
            case "Android (Java) e WebServices SOAP em ASP.NET (C#)":
                return "Android (Java) et SOAP WebServices en ASP.NET (C#)";
            case "Criação e Manutenção de Apps Android e WebServices SOAP relacionados com a Gestão de Vendas em ligação com Software de Faturação para várias empresas (maioritariamente do ramo da Distribuição Alimentar).":
                return "Création et maintenance d'applications Android et de WebServices SOAP liés à la gestion des ventes en relation avec un logiciel de facturation pour plusieurs entreprises (principalement dans le secteur de la distribution alimentaire).";
            case "Criação e Manutenção de Apps Android, WebServices SOAP e Modelação 3D relacionados com a Gestão de Armazém de uma empresa de congelados nacional.":
                return "Création et maintenance d'applications Android, de services Web SOAP et de modélisation 3D pour la gestion de l'entrepôt d'une entreprise nationale de produits surgelés.";
            case "Empresa de Congelados Nacional":
                return "Entreprise portugaise de produits surgelés";
            case "Android (Java), WebServices SOAP em ASP.NET (C#) e Modelação 3D em Babylon.js incoporado em páginas ASP.NET (C#)":
                return "Android (Java), SOAP WebServices en ASP.NET (C#) et modélisation 3D en Babylon.js intégré dans des pages ASP.NET (C#).";
            case "Criação e Manutenção de Apps Android e WebServices SOAP relacionados com a Gestão de Equipamentos e Gestão de Serviços para empresas de vários setores.":
                return "Création et maintenance d'applications Android et de services Web SOAP liés à la gestion des équipements et des services pour des entreprises de divers secteurs.";
            case "Fechar":
                return "Fermer";
            case "WebSites e Softwares":
                return "Sites Web et Logiciels";
            case "Aplicações Android":
                return "Applications Android";
            case "Percurso Pessoal e Profissional":
                return "Carrière Personnelle et Professionnelle";
            case "Desde Setembro 2018":
                return "Depuis septembre 2018";
            case "Mobile Developer (Android)":
                return "Développeur mobile (Android)";
            case "Construção e manutenção de Aplicações Android":
                return "Création et maintenance d'applications Android";
            case "Apoio em Design Aplicacional e Manutenção de Bases de Dados em postgreSQL e SQLite":
                return "Soutien à la conception d'applications et maintenance de bases de données postgreSQL et SQLite";
            case "Fevereiro 2015 - Agosto 2018":
                return "De février 2015 à Août 2018";
            case "Bettertech - Análise e Implementação de Sistemas Informáticos Lda":
                return "Bettertech - Analyse et mise en œuvre de systèmes informatiques Ltd.";
            case "Modelação 3D de Armazéns para Sistema de Gestão Logística":
                return "Modélisation d'entrepôts en 3D pour le système de gestion logistique.";
            case "Mobile Developer (Android) e ASP.NET":
                return "Développeur mobile (Android) et ASP.NET";
            case "Construção e manutenção de WebServices SOAP para consumo das aplicações Android":
                return "Construction et maintenance de WebServices SOAP pour la consommation d'applications Android";
            case "Setembro 2011 - Junho 2012":
                return "De Septembre 2011 à Juin 2012";
            case "Universidade Sénior de Pinhel":
                return "Université Supérieure de Pinhel";
            case "Professor Voluntário de Informática":
                return "Enseignant bénévole en Informatique";
            case "Setembro 2010 - Março 2014":
                return "De Septembre 2010 à Mars 2014";
            case "Universidade da Beira Interior":
                return "Université de Beira Intérieur";
            case "Licenciatura em Engenharia Informática":
                return "Diplôme d'ingénieur en informatique";
            case "Setembro 2008 - Setembro 2010":
                return "De Septembre 2008 à Septembre 2010";
            case "Faculdade de Ciências e Tecnologias - Universidade Nova de Lisboa":
                return "Faculté des sciences et des technologies - Nouvelle Université de Lisbonne";
            case "Frequência no Mestrado Integrado em Engenharia Eletrotécnica e de Computadores":
                return "Participation au Master intégré en génie électrique et informatique";
            case "4<br />Junho<br />1990":
                return "4<br />Juin<br />1990";
            case "Línguas":
                return "Langues";
            case "Língua Materna: Português":
                return "Langue maternelle : Portugais";
            case "Compreensão Oral":
                return "Compréhension orale";
            case "Leitura":
                return "Lecture";
            case "Interação Oral":
                return "Interaction orale";
            case "Produção Oral":
                return "Production orale";
            case "Escrita":
                return "Écriture";
            case "Skills Profissionais":
                return "Compétences Professionnelles";
            case "Web Development (HTML, CSS, JavaScript, jQuery); Java; C; C++; ASP.NET (C#); Android (Java); postgreSQL; SQLite; MySQL; SQL Server":
                return "Développement Web (HTML, CSS, JavaScript, jQuery) ; Java ; C ; C++ ; ASP.NET (C#) ; Android (Java) ; postgreSQL ; SQLite ; MySQL ; SQL Server";
            case "Android Studio; IntelliJ; Microsoft Visual Studio; Microsoft Office; Adobe Photoshop; Adobe Illustrator; DBeaver; SSMS; Microsoft Teams; Jenkins; JIRA; Bitbucket; Confluence;":
                return "Android Studio; IntelliJ; Microsoft Visual Studio; Microsoft Office; Adobe Photoshop; Adobe Illustrator; DBeaver; SSMS; Microsoft Teams; Jenkins; JIRA; Bitbucket; Confluence;";
            case "Formação Complementar":
                return "Formation Complémentaire";
            case "Certificado de Competências Pedagógicas":
                return "Certificat de Compétences Pédagogiques";
            case "Conclusão - Estudos e Formação, Guarda (Portugal)":
                return "Conclusão - Études et formation, Guarda (Portugal)";
            case "Certificado nº F614838/2013":
                return "Certificat nº F614838/2013";
            case "Certificação Cisco CCNA Exploration":
                return "Certification Cisco CCNA Exploration";
            case "Network Fundamentals - Módulo I":
                return "Fondamentaux du réseau - Module I";
            case "Academia Cisco, CFIUTE, Covilhã (Portugal)":
                return "Académie Cisco, CFIUTE, Covilhã (Portugal)";
            case "Nome":
                return "Prénom, Nom";
            case "Por favor, insira um nome válido!":
                return "Veuillez saisir un prénom, nom valide!";
            case "Email":
                return "Adresse Électronique";
            case "Por favor, insira um email válido!":
                return "Veuillez saisir une adresse électronique valide!";
            case "Assunto":
                return "Sujet";
            case "Por favor, insira um assunto válido!":
                return "Veuillez entrer un sujet valide!";
            case "Mensagem":
                return "Message";
            case "Por favor, insira uma mensagem válida!":
                return "Veuillez saisir un message valide!";
            case "Email enviado com sucesso!":
                return "Courriel envoyé avec succès!";
            case "Ocorreu um erro ao enviar o email! Por favor, tente novamente!":
                return "Une erreur s'est produite lors de l'envoi du courriel! Veuillez réessayer!";
            case "Enviar!":
                return "Soumettre!";
            case "Política de Privacidade":
                return "Politique de Confidentialité";
            case "Associação para o Desenvolvimento Sustentável da Região Saloia":
                return "Association pour le développement durable de la région de Saloia";
            case "Turismo Rural":
                return "Tourisme rural";
            case "Consultórios Médicos":
                return "Bureaux médicaux";
            case "Oficina Auto":
                return "Atelier automobile";
            case "Personal Trainer":
                return "Entraîneur personnel";
            case "Herbalife Nutrition Oeste - Distribuidor Independente":
                return "Herbalife Nutrition Oeste - Distributeur Indépendant";
            case "Distribuidor de Produtos Herbalife Nutrition":
                return "Distributeur des produits Herbalife Nutrition";
            case "Junta de Freguesia da Muxagata (Fornos de Algodres, Portugal)":
                return "Mairie de Muxagata (Fornos de Algodres, Portugal)";
            case "Serviços de Engenharia e Consultadoria":
                return "Services d'ingénierie et de conseil";
            case "Soluções de Domótica, Eletricidade, WiFi e Redes Empresariais":
                return "Domotique, électricité, WiFi et solutions pour réseaux d'entreprise";
            case "Fotografia, Vídeo e Publicidade":
                return "Photographie, vidéo et publicité";
            case "Intermediária de Crédito <i>Crédito Comigo</i> e Consultora Imobiliária <i>IAD</i>":
                return "Intermédiaire de crédit pour <i>Crédito Comigo</i> et consultant immobilier <i>IAD</i>";
            case "Publicidade e Artes Gráficas":
                return "Publicité et arts graphiques";
            case "Mediadora de Seguros Ramo Vida e Não Vida Bela Seguros":
                return "Intermédiaire en assurance vie et non-vie Bela Seguros";
            case "Creative | Design | Logo | Merchandising | Publicidade | Photo":
                return "Création | Design | Logo | Merchandising | Publicité | Photo";
            case "Psicóloga Clínica e Formadora":
                return "Psychologue clinicien et formateur";
            case "Artigos para Bebés e Crianças":
                return "Articles pour bébés et enfants";
            case "Osteo & Fit Coach":
                return "Coach Ostéo & Fit";
            case "Largo da Ermida, 14, 1":
                return "Quartier de l'Ermida, 14, 1er Étage";
            case "Rua de Moçambique, 40":
                return "Rue de Moçambique, 40";
            case "Rua José Alberto dos Reis, 122, 4º Esq":
                return "Rue José Alberto dos Reis, 122, 4éme Étage Gauche";
            case "Custo de uma chamada para a rede móvel nacional (Portugal)":
                return "Coût d'un appel vers le réseau mobile national (Portugal)";
            default:
                return word;
        }
    }

    private string getTranslationES(string word)
    {
        switch (word)
        {
            case "Sobre Mim":
                return "Sobre Mí";
            case "Áreas":
                return "Áreas";
            case "Portfolio":
                return "Cartera";
            case "Parceiros":
                return "Socios";
            case "Contactos":
                return "Contactos";
            case "Português":
                return "Portugués";
            case "Francês":
                return "Francés";
            case "Inglês":
                return "Inglés";
            case "Espanhol":
                return "Español";
            case "Alemão":
                return "Alemán";
            case "Programador Android e Web":
                return "Desarrollador Android y Web";
            case "Saiba Mais!":
                return "Más información!";
            case "Confira aqui as Áreas de Especialização!":
                return "Consulte aquí las áreas de especialización";
            case "Desenvolvimento Android":
                return "Desarrollo Android";
            case "Desenvolvimento de Aplicações nativas em Android":
                return "Desarrollo de aplicaciones Android nativas";
            case "Desenvolvimento Web":
                return "Desarrollo Web";
            case "Desenvolvimento de Softwares e WebSites em ASP.NET(C#), com possibilidade de incorporar soluções 3D":
                return "Desarrollo de Software y Sitios Web en ASP.NET(C#), con posibilidad de incorporar soluciones 3D";
            case "WebSite":
                return "Sitio Web";
            case "WebSite com Plataforma de Gestão de Conteúdos":
                return "Sitio Web con PLataforma de Gestión de Contenidos";
            case "Software de Gestão":
                return "Software de Gestión";
            case "Gestão de Máquinas":
                return "Gestión de Máquinas";
            case "Gestão de Máquinas de Dinheiro":
                return "Gestión de Cajeros Automáticos";
            case "Software de Gestão (Em desenvolvimento...)":
                return "Software de Gestión (En desarrollo...)";
            case "Logística":
                return "Logística";
            case "App Android":
                return "Aplicación Android";
            case "Logística e Operação de Campo":
                return "Logística y Operaciones de Campo";
            case "App Android e Modelação 3D":
                return "Aplicación Android y Modelado 3D";
            case "Gestão de Vendas":
                return "Gestión de Ventas";
            case "Gestão de Armazém":
                return "Gestión de Almacenes";
            case "Gestão de Serviços e Equipamentos":
                return "Gestión de Servicios y Equipos";
            case "Programação Web":
                return "Programación Web";
            case "WebSite One Page em HTML com envio de emails em PHP":
                return "Sitio Web HTML de una página con correos PHP";
            case "ASP.NET (C#), Base de Dados SQL Server e Programação Web":
                return "ASP.NET (C#), Base de Datos SQL Server y Programación Web";
            case "WebSite One Page em ASP.NET (C#) com recurso a Base de Dados em SQL Server e Web Pages gerido através de Software construído na mesma base.":
                return "WebSite de una Página en ASP.NET (C#) con recurso a Base de Datos SQL Server y Páginas Web gestionadas a través de Software construido en la misma Base de Datos.";
            case "WebSite em ASP.NET (C#) com recurso a Base de Dados em SQL Server e Web Pages gerido através de Software construído na mesma base.":
                return "WebSite en ASP.NET (C#) con recurso a Base de Datos SQL Server y Páginas Web gestionadas a través de Software construido en la misma base.";
            case "Realização de Software de Gestão em ASP.NET (C#) com recurso a Base de Dados em SQL Server e Web Pages.":
                return "Desarrollo de Software de Gestión en ASP.NET (C#) utilizando Base de Datos SQL Server y Páginas Web.";
            case "Não Divulgado":
                return "No divulgado";
            case "App Android (Java) com manutenção de Bases de Dados SQLite e postgreSQL":
                return "App Android (Java) con mantenimiento de Base de Datos SQLite y PostgreSQL";
            case "Criação e Manutenção de Apps Android relacionadas com todo o processo de uma empresa de Logística (Carregamento de viaturas, entrega de encomendas...)":
                return "Creación y Mantenimiento de Apps Android relacionadas con todo el proceso de una empresa de Logística (Carga de coches, paquetería...)";
            case "Empresa de Telecomunicações Brasileira":
                return "Empresa Brasileña de Telecomunicaciones";
            case "Android (Java e Páginas ASP.NET (C#) Incorporadas em WebViews) e WebServices SOAP em ASP.NET (C#)":
                return "Páginas Android (Java y ASP.NET (C#) embebidas en WebViews) y WebServices SOAP en ASP.NET (C#)";
            case "Criação e Manutenção de Apps Android e WebServices SOAP relacionados com a Gestão de Armazém, Gestão de Transportes e trabalho de campo para uma empresa de telecomunicações brasileira.":
                return "Creación y Mantenimiento de Apps Android y WebServices SOAP relacionados con la Gestión de Almacenes, Gestión de Transporte y trabajo de campo para una empresa de Telecomunicaciones Brasileña.";
            case "Vários":
                return "Varios";
            case "Android (Java) e WebServices SOAP em ASP.NET (C#)":
                return "Android (Java) y SOAP WebServices en ASP.NET (C#)";
            case "Criação e Manutenção de Apps Android e WebServices SOAP relacionados com a Gestão de Vendas em ligação com Software de Faturação para várias empresas (maioritariamente do ramo da Distribuição Alimentar).":
                return "Creación y Mantenimiento de Apps Android y WebServices SOAP relacionados con la Gestión Comercial en conexión con Software de Facturación para varias empresas (mayoritariamente del sector de la Distribución Alimentaria).";
            case "Criação e Manutenção de Apps Android, WebServices SOAP e Modelação 3D relacionados com a Gestão de Armazém de uma empresa de congelados nacional.":
                return "Creación y Mantenimiento de Apps Android, WebServices SOAP y Modelado 3D relacionados con la Gestión de Almacenes de una empresa nacional de congelados.";
            case "Empresa de Congelados Nacional":
                return "Empresa Portuguesa de Alimentos Congelados";
            case "Android (Java), WebServices SOAP em ASP.NET (C#) e Modelação 3D em Babylon.js incoporado em páginas ASP.NET (C#)":
                return "Android (Java), SOAP WebServices en ASP.NET (C#) y Modelado 3D en Babylon.js embebido en páginas ASP.NET (C#)";
            case "Criação e Manutenção de Apps Android e WebServices SOAP relacionados com a Gestão de Equipamentos e Gestão de Serviços para empresas de vários setores.":
                return "Creación y Mantenimiento de Apps Android y WebServices SOAP relacionados con la Gestión de Equipos y Gestión de Servicios para empresas de diversos sectores.";
            case "Fechar":
                return "Cerrar";
            case "WebSites e Softwares":
                return "Sitios Web y Software";
            case "Aplicações Android":
                return "Aplicaciones Android";
            case "Percurso Pessoal e Profissional":
                return "Trayectoria Personal y Profesional";
            case "Desde Setembro 2018":
                return "Desde Septiembre de 2018";
            case "Mobile Developer (Android)":
                return "Desarrollador Móvil (Android)";
            case "Construção e manutenção de Aplicações Android":
                return "Creación y mantenimiento de aplicaciones Android";
            case "Apoio em Design Aplicacional e Manutenção de Bases de Dados em postgreSQL e SQLite":
                return "Soporte al diseño de aplicaciones y mantenimiento de bases de datos en postgreSQL y SQLite";
            case "Fevereiro 2015 - Agosto 2018":
                return "Desde Febrero de 2015 hasta Agosto de 2018";
            case "Bettertech - Análise e Implementação de Sistemas Informáticos Lda":
                return "Bettertech - Análisis e implementación de sistemas informáticos Ltd.";
            case "Modelação 3D de Armazéns para Sistema de Gestão Logística":
                return "Modelado de almacenes en 3D para sistema de gestión logística";
            case "Mobile Developer (Android) e ASP.NET":
                return "Desarrollador Móvil (Android) y ASP.NET";
            case "Construção e manutenção de WebServices SOAP para consumo das aplicações Android":
                return "Construcción y mantenimiento de WebServices SOAP para consumo de aplicaciones Android";
            case "Setembro 2011 - Junho 2012":
                return "Desde Septiembre de 2011 hasta Junio de 2012";
            case "Universidade Sénior de Pinhel":
                return "Universidad Senior de Pinhel";
            case "Professor Voluntário de Informática":
                return "Profesor Voluntario de Informática";
            case "Setembro 2010 - Março 2014":
                return "Desde Septiembre de 2010 hasta Marzo de 2014";
            case "Universidade da Beira Interior":
                return "Universidad de Beira Interior";
            case "Licenciatura em Engenharia Informática":
                return "Grado en Ingeniería Informática";
            case "Setembro 2008 - Setembro 2010":
                return "Desde Septiembre de 2008 hasta Septiembre de 2010";
            case "Faculdade de Ciências e Tecnologias - Universidade Nova de Lisboa":
                return "Facultad de Ciencias y Tecnologías - Nueva Universidad de Lisboa";
            case "Frequência no Mestrado Integrado em Engenharia Eletrotécnica e de Computadores":
                return "Asistencia al Máster Integrado en Ingeniería Eléctrica e Informática";
            case "4<br />Junho<br />1990":
                return "4<br />Junio<br />1990";
            case "Línguas":
                return "Idiomas";
            case "Língua Materna: Português":
                return "Lengua materna: Portugués";
            case "Compreensão Oral":
                return "Comprensión auditiva";
            case "Leitura":
                return "Lectura";
            case "Interação Oral":
                return "Interacción oral";
            case "Produção Oral":
                return "Producción oral";
            case "Escrita":
                return "Escritura";
            case "Skills Profissionais":
                return "Competencias Profesionales";
            case "Web Development (HTML, CSS, JavaScript, jQuery); Java; C; C++; ASP.NET (C#); Android (Java); postgreSQL; SQLite; MySQL; SQL Server":
                return "Desarrollo web (HTML, CSS, JavaScript, jQuery); Java; C; C++; ASP.NET (C#); Android (Java); postgreSQL; SQLite; MySQL; SQL Server";
            case "Android Studio; IntelliJ; Microsoft Visual Studio; Microsoft Office; Adobe Photoshop; Adobe Illustrator; DBeaver; SSMS; Microsoft Teams; Jenkins; JIRA; Bitbucket; Confluence;":
                return "Android Studio; IntelliJ; Microsoft Visual Studio; Microsoft Office; Adobe Photoshop; Adobe Illustrator; DBeaver; SSMS; Microsoft Teams; Jenkins; JIRA; Bitbucket; Confluence;";
            case "Formação Complementar":
                return "Formación Complementaria";
            case "Certificado de Competências Pedagógicas":
                return "Certificado de Aptitudes Pedagógicas";
            case "Conclusão - Estudos e Formação, Guarda (Portugal)":
                return "Conclusão - Estudios y Formación, Guarda (Portugal)";
            case "Certificado nº F614838/2013":
                return "Certificado nº F614838/2013";
            case "Certificação Cisco CCNA Exploration":
                return "Certificación Cisco CCNA Exploration";
            case "Network Fundamentals - Módulo I":
                return "Fundamentos de Red - Módulo I";
            case "Academia Cisco, CFIUTE, Covilhã (Portugal)":
                return "Academia Cisco, CFIUTE, Covilhã (Portugal)";
            case "Nome":
                return "Nombre";
            case "Por favor, insira um nome válido!":
                return "¡Por favor, introduzca un nombre válido!";
            case "Email":
                return "Correo electrónico";
            case "Por favor, insira um email válido!":
                return "¡Por favor, introduzca una dirección de correo electrónico válida!";
            case "Assunto":
                return "Asunto";
            case "Por favor, insira um assunto válido!":
                return "¡Por favor, introduzca un asunto válido!";
            case "Mensagem":
                return "Mensaje";
            case "Por favor, insira uma mensagem válida!":
                return "¡Por favor, introduzca un mensaje válido!";
            case "Email enviado com sucesso!":
                return "¡El mensaje se ha enviado correctamente!";
            case "Ocorreu um erro ao enviar o email! Por favor, tente novamente!":
                return "¡Se ha producido un error al enviar el correo electrónico! ¡Vuelva a intentarlo!";
            case "Enviar!":
                return "¡Enviar!";
            case "Política de Privacidade":
                return "Política de Privacidad";
            case "Associação para o Desenvolvimento Sustentável da Região Saloia":
                return "Asociación para el Desarrollo Sostenible de la Región de Saloia";
            case "Turismo Rural":
                return "Turismo Rural";
            case "Consultórios Médicos":
                return "Consultorios Médicos";
            case "Oficina Auto":
                return "Taller de coches";
            case "Personal Trainer":
                return "Entrenador Personal";
            case "Herbalife Nutrition Oeste - Distribuidor Independente":
                return "Herbalife Nutrition Oeste - Distribuidor Independiente";
            case "Distribuidor de Produtos Herbalife Nutrition":
                return "Distribuidor de Productos de Nutrición Herbalife";
            case "Junta de Freguesia da Muxagata (Fornos de Algodres, Portugal)":
                return "Ayuntamiento de Muxagata (Fornos de Algodres, Portugal)";
            case "Serviços de Engenharia e Consultadoria":
                return "Servicios de Ingeniería y Consultoría";
            case "Soluções de Domótica, Eletricidade, WiFi e Redes Empresariais":
                return "Soluciones de Domótica, Electricidad, WiFi y Redes Empresariales";
            case "Fotografia, Vídeo e Publicidade":
                return "Fotografía, Vídeo y Publicidad";
            case "Intermediária de Crédito <i>Crédito Comigo</i> e Consultora Imobiliária <i>IAD</i>":
                return "Intermediario de Crédito para <i>Crédito Comigo</i> y Consultor Inmobiliario <i>IAD</i>";
            case "Publicidade e Artes Gráficas":
                return "Publicidad y Artes Gráficas";
            case "Mediadora de Seguros Ramo Vida e Não Vida Bela Seguros":
                return "Intermediario de Seguros Vida y No Vida Bela Seguros";
            case "Creative | Design | Logo | Merchandising | Publicidade | Photo":
                return "Creatividad | Diseño | Logotipo | Merchandising | Publicidad | Fotografía";
            case "Psicóloga Clínica e Formadora":
                return "Psicóloga Clínica y Formadora";
            case "Artigos para Bebés e Crianças":
                return "Artículos para Bebés y Niños";
            case "Osteo & Fit Coach":
                return "Osteo & Fit Coach";
            case "Largo da Ermida, 14, 1":
                return "Plaza de la Ermida, 14, 1ª Planta";
            case "Rua de Moçambique, 40":
                return "Calle de Moçambique, 40";
            case "Rua José Alberto dos Reis, 122, 4º Esq":
                return "Calle José Alberto dos Reis, 122, 4ª Planta Izquierda";
            case "Custo de uma chamada para a rede móvel nacional (Portugal)":
                return "Coste de una llamada a la red móvil nacional (Portugal)";
            default:
                return word;
        }
    }

    private string getTranslationDE(string word)
    {
        switch (word)
        {
            case "Sobre Mim":
                return "Über mich";
            case "Áreas":
                return "Bereiche";
            case "Portfolio":
                return "Portfolio";
            case "Parceiros":
                return "Partner";
            case "Contactos":
                return "Kontakte";
            case "Português":
                return "Portugiesisch";
            case "Francês":
                return "Französisch";
            case "Inglês":
                return "Englisch";
            case "Espanhol":
                return "Spanisch";
            case "Alemão":
                return "Deutsch";
            case "Programador Android e Web":
                return "Android und Web-Entwickler";
            case "Saiba Mais!":
                return "Mehr Erfahren!";
            case "Confira aqui as Áreas de Especialização!":
                return "Prüfen Sie hier die Spezialisierungsbereiche!";
            case "Desenvolvimento Android":
                return "Android Entwicklung";
            case "Desenvolvimento de Aplicações nativas em Android":
                return "Native Android Anwendungsentwicklung";
            case "Desenvolvimento Web":
                return "Web-Entwicklung";
            case "Desenvolvimento de Softwares e WebSites em ASP.NET(C#), com possibilidade de incorporar soluções 3D":
                return "Software und Website-Entwicklung in ASP.NET(C#), mit der Möglichkeit, 3D-Lösungen einzubauen";
            case "WebSite":
                return "Internetauftritt";
            case "WebSite com Plataforma de Gestão de Conteúdos":
                return "Website mit Content-Management-Plattform";
            case "Software de Gestão":
                return "Verwaltungssoftware";
            case "Gestão de Máquinas":
                return "Maschine Management";
            case "Gestão de Máquinas de Dinheiro":
                return "Verwaltung von Geldautomaten";
            case "Software de Gestão (Em desenvolvimento...)":
                return "Verwaltungssoftware (in Entwicklung...)";
            case "Logística":
                return "Logistik";
            case "App Android":
                return "Android-Anwendung";
            case "Logística e Operação de Campo":
                return "Logistik und Feldeinsatz";
            case "App Android e Modelação 3D":
                return "Android-Anwendung und 3D-Modellierung";
            case "Gestão de Vendas":
                return "Vertriebsmanagement";
            case "Gestão de Armazém":
                return "Lagerverwaltung";
            case "Gestão de Serviços e Equipamentos":
                return "Service und Geräteverwaltung";
            case "Programação Web":
                return "Web-Programmierung";
            case "WebSite One Page em HTML com envio de emails em PHP":
                return "Eine Seite HTML WebSite mit PHP Mailings";
            case "ASP.NET (C#), Base de Dados SQL Server e Programação Web":
                return "ASP.NET (C#), SQL Server-Datenbank und Web-Programmierung";
            case "WebSite One Page em ASP.NET (C#) com recurso a Base de Dados em SQL Server e Web Pages gerido através de Software construído na mesma base.":
                return "Eine Seite WebSite in ASP.NET (C#) mit Ressource zu SQL Server Datenbank und Webseiten verwaltet durch Software in der gleichen Datenbank gebaut.";
            case "WebSite em ASP.NET (C#) com recurso a Base de Dados em SQL Server e Web Pages gerido através de Software construído na mesma base.":
                return "WebSite in ASP.NET (C#) mit Ressource zu SQL Server-Datenbank und Web-Seiten durch Software in der gleichen Basis gebaut verwaltet.";
            case "Realização de Software de Gestão em ASP.NET (C#) com recurso a Base de Dados em SQL Server e Web Pages.":
                return "Entwicklung von Verwaltungssoftware in ASP.NET (C#) mit SQL Server-Datenbank und Webseiten.";
            case "Não Divulgado":
                return "Nicht offengelegt";
            case "App Android (Java) com manutenção de Bases de Dados SQLite e postgreSQL":
                return "Android App (Java) mit SQLite und PostgreSQL Datenbank Wartung";
            case "Criação e Manutenção de Apps Android relacionadas com todo o processo de uma empresa de Logística (Carregamento de viaturas, entrega de encomendas...)":
                return "Erstellung und Wartung von Android Apps, die mit allen Prozessen eines Logistikunternehmens zusammenhängen (Autoverladung, Paketzustellung...)";
            case "Empresa de Telecomunicações Brasileira":
                return "Brasilianisches Telekommunikationsunternehmen";
            case "Android (Java e Páginas ASP.NET (C#) Incorporadas em WebViews) e WebServices SOAP em ASP.NET (C#)":
                return "Android (Java und ASP.NET (C#) Seiten eingebettet in WebViews) und SOAP WebServices in ASP.NET (C#)";
            case "Criação e Manutenção de Apps Android e WebServices SOAP relacionados com a Gestão de Armazém, Gestão de Transportes e trabalho de campo para uma empresa de telecomunicações brasileira.":
                return "Erstellung und Pflege von Android-Apps und SOAP-WebServices im Zusammenhang mit Lagerverwaltung, Transportmanagement und Außendienst für ein brasilianisches Telekommunikationsunternehmen.";
            case "Vários":
                return "Verschiedene";
            case "Android (Java) e WebServices SOAP em ASP.NET (C#)":
                return "Android (Java) und SOAP-WebServices in ASP.NET (C#)";
            case "Criação e Manutenção de Apps Android e WebServices SOAP relacionados com a Gestão de Vendas em ligação com Software de Faturação para várias empresas (maioritariamente do ramo da Distribuição Alimentar).":
                return "Erstellung und Wartung von Android Apps und SOAP WebServices im Zusammenhang mit Sales Management in Verbindung mit Invoicing Software für verschiedene Unternehmen (hauptsächlich aus der Lebensmittelbranche).";
            case "Criação e Manutenção de Apps Android, WebServices SOAP e Modelação 3D relacionados com a Gestão de Armazém de uma empresa de congelados nacional.":
                return "Erstellung und Pflege von Android-Apps, SOAP WebServices und 3D-Modellierung im Zusammenhang mit der Lagerverwaltung eines nationalen Tiefkühlkostunternehmens.";
            case "Empresa de Congelados Nacional":
                return "Portugiesisches Unternehmen für Tiefkühlkost";
            case "Android (Java), WebServices SOAP em ASP.NET (C#) e Modelação 3D em Babylon.js incoporado em páginas ASP.NET (C#)":
                return "Android (Java), SOAP WebServices in ASP.NET (C#) und 3D Modellierung in Babylon.js eingebettet in ASP.NET (C#) Seiten";
            case "Criação e Manutenção de Apps Android e WebServices SOAP relacionados com a Gestão de Equipamentos e Gestão de Serviços para empresas de vários setores.":
                return "Erstellung und Pflege von Android-Apps und SOAP-WebServices im Zusammenhang mit der Verwaltung von Geräten und Dienstleistungen für Unternehmen aus verschiedenen Sektoren.";
            case "Fechar":
                return "Schließen Sie";
            case "WebSites e Softwares":
                return "WebSites und Softwares";
            case "Aplicações Android":
                return "Android-Anwendungen";
            case "Percurso Pessoal e Profissional":
                return "Persönlicher und beruflicher Werdegang";
            case "Desde Setembro 2018":
                return "Seit September 2018";
            case "Mobile Developer (Android)":
                return "Mobile Entwickler (Android)";
            case "Construção e manutenção de Aplicações Android":
                return "Erstellung und Pflege von Android-Anwendungen";
            case "Apoio em Design Aplicacional e Manutenção de Bases de Dados em postgreSQL e SQLite":
                return "Unterstützung beim Anwendungsdesign und Wartung von Datenbanken in postgreSQL und SQLite";
            case "Fevereiro 2015 - Agosto 2018":
                return "Februar 2015 - August 2018";
            case "Bettertech - Análise e Implementação de Sistemas Informáticos Lda":
                return "Bettertech - Analyse und Implementierung von Computersystemen Ltd.";
            case "Modelação 3D de Armazéns para Sistema de Gestão Logística":
                return "3D-Lagermodellierung für Logistikmanagementsystem";
            case "Mobile Developer (Android) e ASP.NET":
                return "Mobile Entwickler (Android) und ASP.NET";
            case "Construção e manutenção de WebServices SOAP para consumo das aplicações Android":
                return "Aufbau und Pflege von SOAP WebServices für die Nutzung von Android-Anwendungen";
            case "Setembro 2011 - Junho 2012":
                return "September 2011 - Juni 2012";
            case "Universidade Sénior de Pinhel":
                return "Senior Universität Pinhel";
            case "Professor Voluntário de Informática":
                return "Freiwilliger Informatik-Lehrer";
            case "Setembro 2010 - Março 2014":
                return "September 2010 - März 2014";
            case "Universidade da Beira Interior":
                return "Universität von Beira Interior";
            case "Licenciatura em Engenharia Informática":
                return "Studium der technischen Informatik";
            case "Setembro 2008 - Setembro 2010":
                return "September 2008 - September 2010";
            case "Faculdade de Ciências e Tecnologias - Universidade Nova de Lisboa":
                return "Fakultät für Wissenschaften und Technologien - Neue Universität Lissabon";
            case "Frequência no Mestrado Integrado em Engenharia Eletrotécnica e de Computadores":
                return "Besuch des Integrierten Masterstudiengangs in Elektrotechnik und Computertechnik";
            case "4<br />Junho<br />1990":
                return "4.<br />Juni<br />1990";
            case "Línguas":
                return "Sprachen";
            case "Língua Materna: Português":
                return "Muttersprache: Portugiesisch";
            case "Compreensão Oral":
                return "Hörverstehen";
            case "Leitura":
                return "Lesen";
            case "Interação Oral":
                return "Mündliche Interaktion";
            case "Produção Oral":
                return "Gesprochene Produktion";
            case "Escrita":
                return "Schreiben";
            case "Skills Profissionais":
                return "Berufliche Fähigkeiten";
            case "Web Development (HTML, CSS, JavaScript, jQuery); Java; C; C++; ASP.NET (C#); Android (Java); postgreSQL; SQLite; MySQL; SQL Server":
                return "Webentwicklung (HTML, CSS, JavaScript, jQuery); Java; C; C++; ASP.NET (C#); Android (Java); postgreSQL; SQLite; MySQL; SQL Server";
            case "Android Studio; IntelliJ; Microsoft Visual Studio; Microsoft Office; Adobe Photoshop; Adobe Illustrator; DBeaver; SSMS; Microsoft Teams; Jenkins; JIRA; Bitbucket; Confluence;":
                return "Android Studio; IntelliJ; Microsoft Visual Studio; Microsoft Office; Adobe Photoshop; Adobe Illustrator; DBeaver; SSMS; Microsoft Teams; Jenkins; JIRA; Bitbucket; Confluence;";
            case "Formação Complementar":
                return "Ergänzende Ausbildung";
            case "Certificado de Competências Pedagógicas":
                return "Zertifikat für pädagogische Fähigkeiten";
            case "Conclusão - Estudos e Formação, Guarda (Portugal)":
                return "Conclusão - Studium und Ausbildung, Guarda (Portugal)";
            case "Certificado nº F614838/2013":
                return "Zertifikat nº F614838/2013";
            case "Certificação Cisco CCNA Exploration":
                return "Cisco CCNA Exploration Zertifizierung";
            case "Network Fundamentals - Módulo I":
                return "Netzwerk-Grundlagen - Modul I";
            case "Academia Cisco, CFIUTE, Covilhã (Portugal)":
                return "Cisco Akademie, CFIUTE, Covilhã (Portugal)";
            case "Nome":
                return "Name";
            case "Por favor, insira um nome válido!":
                return "Bitte geben Sie einen gültigen Namen ein!";
            case "Email":
                return "E-Mail";
            case "Por favor, insira um email válido!":
                return "Bitte geben Sie eine gültige E-Mail Adresse ein!";
            case "Assunto":
                return "Betreff";
            case "Por favor, insira um assunto válido!":
                return "Bitte geben Sie einen gültigen Betreff ein!";
            case "Mensagem":
                return "Nachricht";
            case "Por favor, insira uma mensagem válida!":
                return "Bitte geben Sie eine gültige Nachricht ein!";
            case "Email enviado com sucesso!":
                return "E-Mail erfolgreich gesendet!";
            case "Ocorreu um erro ao enviar o email! Por favor, tente novamente!":
                return "Beim Senden der E-Mail ist ein Fehler aufgetreten! Bitte versuchen Sie es erneut!";
            case "Enviar!":
                return "Abschicken!";
            case "Política de Privacidade":
                return "Datenschutzrichtlinien";
            case "Associação para o Desenvolvimento Sustentável da Região Saloia":
                return "Verein für die nachhaltige Entwicklung der Region Saloia";
            case "Turismo Rural":
                return "Ländlicher Tourismus";
            case "Consultórios Médicos":
                return "Medizinische Ämter";
            case "Oficina Auto":
                return "Autowerkstatt";
            case "Personal Trainer":
                return "Personal Trainer";
            case "Herbalife Nutrition Oeste - Distribuidor Independente":
                return "Herbalife Nutrition Oeste - Unabhängiger Vertriebspartner";
            case "Distribuidor de Produtos Herbalife Nutrition":
                return "Vertriebshändler für Herbalife Nutrition Produkte";
            case "Junta de Freguesia da Muxagata (Fornos de Algodres, Portugal)":
                return "Stadtverwaltung von Muxagata (Fornos de Algodres, Portugal)";
            case "Serviços de Engenharia e Consultadoria":
                return "Ingenieur-und Beratungsdienste";
            case "Soluções de Domótica, Eletricidade, WiFi e Redes Empresariais":
                return "Domotik, Elektrizität, WiFi und Unternehmensnetzwerklösungen";
            case "Fotografia, Vídeo e Publicidade":
                return "Fotografie, Video und Werbung";
            case "Intermediária de Crédito <i>Crédito Comigo</i> e Consultora Imobiliária <i>IAD</i>":
                return "Kreditvermittler für <i>Crédito Comigo</i> und Immobilienberater <i>IAD</i>";
            case "Publicidade e Artes Gráficas":
                return "Werbung und grafische Künste";
            case "Mediadora de Seguros Ramo Vida e Não Vida Bela Seguros":
                return "Versicherungsvermittler Leben und Nicht-Leben Bela Seguros";
            case "Creative | Design | Logo | Merchandising | Publicidade | Photo":
                return "Kreativ | Design | Logo | Merchandising | Werbung | Foto";
            case "Psicóloga Clínica e Formadora":
                return "Klinischer Psychologe und Trainer";
            case "Artigos para Bebés e Crianças":
                return "Artikel für Babies und Kinder";
            case "Osteo & Fit Coach":
                return "Osteo & Fit Coach";
            case "Largo da Ermida, 14, 1":
                return "Ermid-Platz, 14, 1. Stockwerk";
            case "Rua de Moçambique, 40":
                return "Moçambique Straße, 40";
            case "Rua José Alberto dos Reis, 122, 4º Esq":
                return "José Alberto dos Reis Straße, 122, 4. Stockwerk Links";
            case "Custo de uma chamada para a rede móvel nacional (Portugal)":
                return "Kosten für einen Anruf in das nationale Mobilfunknetz (Portugal)";
            default:
                return word;
        }
    }
}
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="Website oficial de André Afonso Lourenço" />
        <meta name="author" content="André Afonso Lourenço" />
        <title>André Afonso Lourenço WebSite</title>
        <!-- Favicon-->
        <link rel="icon" type="image/x-icon" href="assets/favicon.ico" />
        <!-- Google fonts-->
        <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css" />
        <link href="https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700" rel="stylesheet" type="text/css" />
        <!-- Core theme CSS (includes Bootstrap)-->
        <link href="css/styles.css" rel="stylesheet" />

        <style type="text/css">
            .fab-container {
                position:fixed;
                bottom:50px;
                right:50px;
                cursor:pointer;
            }

            .iconbutton {
                width:50px;
                height:50px;
                border-radius: 100%;
                background: #FFF;
                /*box-shadow: 10px 10px 5px #aaaaaa;*/
            }

            .icon {
                display:flex;
                align-items:center;
                justify-content:center;
                height: 100%;
                width: auto;
                color: #FFF;
            }

            .button {
                width:60px;
                height:60px;
                background:#FFF
            }

            .options {
                list-style-type: none;
                position:absolute;
                bottom:70px;
                right:0;
                transition: all 2s linear;
            }

            .options li {
                display:flex;
                justify-content:flex-end;
                padding:5px;
            }

            .btn-label {
                padding:2px 5px;
                margin-right:10px;
                align-self: center;
                user-select:none;
                background-color: black;
                color:white;
                border-radius: 3px;
                box-shadow: 10px 10px 5px #aaaaaa;
            }

            .black_overlay {
                display: none;
                position: fixed;
                top: 0%;
                left: 0%;
                width: 100%;
                height: 100%;
                background: rgba(0,0,0,0.9);
                z-index: 1060 !important;
            }

            .divLanguages {
                position: fixed;
                top: 50%;
                left: 50%;
                -webkit-transform: translate(-50%, -50%);
                -moz-transform: translate(-50%, -50%);
                -ms-transform: translate(-50%, -50%);
                -o-transform: translate(-50%, -50%);
                transform: translate(-50%, -50%);
                width: 75%;
                height: 25%;
                z-index: 1061 !important;
                opacity: 1;
                max-height: 90%;
                display: none;
            }
        </style>
    </head>
    <body id="page-top">
        <!-- Navigation-->
        <nav class="navbar navbar-expand-lg navbar-dark fixed-top" id="mainNav" runat="server"></nav>

        <!-- Masthead-->
        <header class="masthead" id="header" runat="server"></header>

        <!-- About-->
        <section class="page-section" id="about" runat="server"></section>

        <!-- Services-->
        <section class="page-section" id="services" runat="server"></section>

        <!-- Portfolio Grid-->
        <section class="page-section bg-light" id="portfolio" runat="server"></section>

        <!-- Team-->
        <section class="page-section bg-light" id="team" runat="server"></section>

        <!-- Contact-->
        <section class="page-section" id="contact" runat="server"></section>

        <!-- Footer-->
        <footer class="footer py-4" id="footer" runat="server"></footer>

        <!-- Portfolio Modals-->
        <div id="porfolioModals" runat="server"></div>

        <!-- Privacy Policy -->
        <div id="privacyPolicy" runat="server" class="black_overlay"></div>

        <div class="fab-container" id="fabLanguage" runat="server"></div>

        <div id="hiddenValues" class="variaveis">
            <span id="txtAuxLanguage" runat="server"></span>
            <span id="txtAuxBG" runat="server"></span>
        </div>

        <!-- Font Awesome icons (free version)-->
        <script src="https://use.fontawesome.com/releases/v5.15.3/js/all.js" crossorigin="anonymous"></script>

        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.3/jquery.min.js"></script>
        <!-- Bootstrap core JS-->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js"></script>
        <!-- Core theme JS-->
        <script src="js/scripts.js"></script>

        <script type="text/javascript">
            $(document).ready(function () {
                adjustHeights();

                var bg = $('#txtAuxBG').html();

                if (bg == 'KK77.jpg') {
                    $('#header').css({ "background-image": 'url(assets/img/bg_personal.jpg)' });
                }

                $('#contact').css({ "background-image": 'url(assets/img/worldmap.png)' });
            });

            $(window).on('resize', function () {
                adjustHeights();
            });

            function adjustHeights() {
                $('#header').css('width', '100vw');
                $('#header').css('height', '100vh');

                var h = $('#divInfoAddress').height();
                $('#divInfoEmail').height(h);
                $('#divInfoPhone').height(h);

                var hForm = $('#divFormNameEmailSubject').height();
                $('#divFormMessage').height(hForm);
                $('#message').css('max-height', hForm + 'px');
                $('#message').height(hForm);
            }

            function sendEmail() {
                $('#invalidName').fadeOut();
                $('#invalidEmail').fadeOut();
                $('#invalidSubject').fadeOut();
                $('#invalidMessage').fadeOut();

                var assunto = $('#subject').val().trim();
                var nome = $('#name').val().trim();
                var email = $('#email').val().trim();
                var body = $('#message').val().trim();
                var lang = $('#txtAuxLanguage').html();

                if (nome == '' || nome == undefined || nome.length == 0) {
                    $('#invalidName').fadeIn();
                    setTimeout(function () { $("#invalidName").fadeOut(); }, 5000);
                    return;
                }

                if (email == '' || email == undefined || email.length == 0 || !validateEmail(email)) {
                    $('#invalidEmail').fadeIn();
                    setTimeout(function () { $("#invalidEmail").fadeOut(); }, 5000);
                    return;
                }

                if (assunto == '' || assunto == undefined || assunto.length == 0) {
                    $('#invalidSubject').fadeIn();
                    setTimeout(function () { $("#invalidSubject").fadeOut(); }, 5000);
                    return;
                }

                if (body == '' || body == undefined || body.length == 0) {
                    $('#invalidMessage').fadeIn();
                    setTimeout(function () { $("#invalidMessage").fadeOut(); }, 5000);
                    return;
                }

                $.ajax({
                    type: "POST",
                    url: "index.aspx/sendEmailFromTemplate",
                    data: '{"assunto":"' + assunto + '", "nome":"' + nome + '", "email":"' + email + '", "body":"' + body + '", "language":"' + lang + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (res) {
                        if (res.d != null) {
                            if (parseInt(res.d) >= 0) {
                                $('#subject').val('');
                                $('#name').val('');
                                $('#email').val('');
                                $('#message').val('');
                                $('#submitErrorMessage').addClass('d-none');
                                $("#submitSuccessMessage").removeClass('d-none');
                                setTimeout(function () { $("#submitSuccessMessage").addClass('d-none'); }, 5000);
                            }
                            else {
                                $('#submitErrorMessage').removeClass('d-none');
                            }
                        }
                    }
                });
            }

            function validateEmail(str) {
                var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
                return str.match(validRegex);
            }

            function openCloseLanguagesDialog() {
                if ($('#fabOptions').hasClass('d-none')) {
                    $('#fabOptions').removeClass('d-none');
                }
                else {
                    $('#fabOptions').addClass('d-none');
                }
            }

            function openPrivacyPolicy() {
                $('#privacyPolicy').fadeIn();
                $('#dialogPrivacyPolicy').fadeIn();
            }

            function closePrivacyPolicy() {
                $('#privacyPolicy').fadeOut();
                $('#dialogPrivacyPolicy').fadeOut();
            }

            function changeLanguagePage(language) {
                var contents = $('#txtAuxBG').html() == 'KK77.jpg' ? 'pass=KK77' : '';
                var lang = '';

                if (language == 34) {
                    lang = 'language=ES';
                } else if (language == 33) {
                    lang = 'language=FR';
                } else if (language == 49) {
                    lang = 'language=DE';
                } else if (language == 44) {
                    lang = 'language=EN';
                } else {
                    lang = 'language=PT';
                }

                contents = contents != '' ? ('?' + contents + '&' + lang) : ('?' + lang);

                if (window.location.href.includes('localhost')) {
                    window.location.href = 'index.aspx' + contents;
                } else {
                    window.location.href = 'https://andreafonsolourenco.pt/index.aspx' + contents;
                }
            }
        </script>
    </body>
</html>
using System.Collections.Generic;
using BackToOwner.Golf.Web.Models;
using NHibernate;

namespace BackToOwner.Web.Setup
{
    public class DefaultResourceCreation : NHResourceCreation
    {
        public DefaultResourceCreation(ISession currentSession)
            : base(currentSession)
        { }
        
        public static List<Resource> CreateResources()
        {
            var resources = new List<Resource>();
            resources.Add(new Resource()
            {
                Label = "homeView_title",
                Language = "fr",
                Value = "titre de la home page"
            });
            resources.Add(new Resource()
            {
                Label = "homeView_title",
                Language = "nl",
                Value = "title van de home pagina"
            });
            resources.Add(new Resource()
            {
                Label = "homeView_title",
                Language = "en",
                Value = "title of the homepage"
            });
            resources.Add(new Resource()
            {
                Label = "homeView_text",
                Language = "en",
                Value = "Enter your badgenumber here"
            });
            resources.Add(new Resource()
            {
                Label = "homeView_text",
                Language = "fr",
                Value = "Entrez le n° de votre badge"
            });
            resources.Add(new Resource()
            {
                Label = "homeView_text",
                Language = "nl",
                Value = "Vul hier uw badge nummer in"
            });
            resources.Add(new Resource()
            {
                Label = "err_required",
                Language = "fr",
                Value = "* obligatoire"
            });
            resources.Add(new Resource()
            {
                Label = "err_required",
                Language = "nl",
                Value = "* Verplichte veld"
            });
            resources.Add(new Resource()
            {
                Label = "err_required",
                Language = "en",
                Value = "* Required"
            });

            resources.Add(new Resource()
            {
                Label = "activate_title",
                Language = "fr",
                Value = "Activez le service GOLFLABEL.NET"
            });
            resources.Add(new Resource()
            {
                Label = "activate_title",
                Language = "en",
                Value = "Activate the service GOLFLABEL.NET"
            });
            resources.Add(new Resource()
            {
                Label = "activate_title",
                Language = "nl",
                Value = "Activeren van de GOLFLABEL.NET service"
            });
            resources.Add(new Resource()
            {
                Label = "activate_body",
                Language = "fr",
                Value = "Indiquez vos données personelles"
            });
            resources.Add(new Resource()
            {
                Label = "activate_body",
                Language = "en",
                Value = "Your personal information"
            });
            resources.Add(new Resource()
            {
                Label = "activate_body",
                Language = "nl",
                Value = "Vul youw persoonijke informatie in!"
            });
            resources.Add(new Resource()
            {
                Label = "firstname",
                Language = "fr",
                Value = "Prénom"
            });
            resources.Add(new Resource()
            {
                Label = "firstname",
                Language = "nl",
                Value = "Voornaam"
            });
            resources.Add(new Resource()
            {
                Label = "firstname",
                Language = "en",
                Value = "Firstname"
            });
            resources.Add(new Resource()
            {
                Label = "lastname",
                Language = "fr",
                Value = "Nom"
            });
            resources.Add(new Resource()
            {
                Label = "lastname",
                Language = "en",
                Value = "Name"
            });
            resources.Add(new Resource()
            {
                Label = "lastname",
                Language = "nl",
                Value = "Naam"
            });
            resources.Add(new Resource()
            {
                Label = "gender",
                Language = "fr",
                Value = "Monsieur/Madame"
            });
            resources.Add(new Resource()
            {
                Label = "gender",
                Language = "en",
                Value = "Man/Woman"
            });
            resources.Add(new Resource()
            {
                Label = "gender",
                Language = "nl",
                Value = "Aanspreking"
            });
            resources.Add(new Resource()
            {
                Label = "phone_business",
                Language = "fr",
                Value = "Téléphone (travaille)"
            });
            resources.Add(new Resource()
            {
                Label = "phone_business",
                Language = "en",
                Value = "Phone (Business)"
            });
            resources.Add(new Resource()
            {
                Label = "phone_business",
                Language = "nl",
                Value = "Telefoon (werk)"
            });
            resources.Add(new Resource()
            {
                Label = "phone_private",
                Language = "fr",
                Value = "Téléphone (privé)"
            });
            resources.Add(new Resource()
            {
                Label = "phone_private",
                Language = "en",
                Value = "Phone (private)"
            });
            resources.Add(new Resource()
            {
                Label = "phone_private",
                Language = "nl",
                Value = "Telefoon (prive)"
            });
            resources.Add(new Resource()
            {
                Label = "example",
                Language = "fr",
                Value = "022678821"
            });
            resources.Add(new Resource()
            {
                Label = "example",
                Language = "en",
                Value = "022678821"
            });
            resources.Add(new Resource()
            {
                Label = "example",
                Language = "nl",
                Value = "022678821"
            });

            resources.Add(new Resource()
            {
                Label = "phone_mobile",
                Language = "fr",
                Value = "Mobile"
            });
            resources.Add(new Resource()
            {
                Label = "phone_mobile",
                Language = "en",
                Value = "Mobile"
            });
            resources.Add(new Resource()
            {
                Label = "phone_mobile",
                Language = "nl",
                Value = "Mobiel"
            });

            resources.Add(new Resource()
            {
                Label = "street",
                Language = "fr",
                Value = "Rue"
            });
            resources.Add(new Resource()
            {
                Label = "street",
                Language = "en",
                Value = "Street"
            });
            resources.Add(new Resource()
            {
                Label = "street",
                Language = "nl",
                Value = "Straat"
            });

            resources.Add(new Resource()
            {
                Label = "nbr",
                Language = "fr",
                Value = "N°"
            });
            resources.Add(new Resource()
            {
                Label = "nbr",
                Language = "en",
                Value = "Nbr"
            });
            resources.Add(new Resource()
            {
                Label = "nbr",
                Language = "nl",
                Value = "N°"
            });

            resources.Add(new Resource()
            {
                Label = "city",
                Language = "fr",
                Value = "Ville"
            });
            resources.Add(new Resource()
            {
                Label = "city",
                Language = "en",
                Value = "City"
            });
            resources.Add(new Resource()
            {
                Label = "city",
                Language = "nl",
                Value = "Stad"
            });

            resources.Add(new Resource()
            {
                Label = "zipcode",
                Language = "fr",
                Value = "Code postal"
            });
            resources.Add(new Resource()
            {
                Label = "zipcode",
                Language = "en",
                Value = "Zip"
            });
            resources.Add(new Resource()
            {
                Label = "zipcode",
                Language = "nl",
                Value = "Postcode"
            });

            resources.Add(new Resource()
            {
                Label = "country",
                Language = "fr",
                Value = "Pays"
            });
            resources.Add(new Resource()
            {
                Label = "country",
                Language = "en",
                Value = "Country"
            });
            resources.Add(new Resource()
            {
                Label = "country",
                Language = "nl",
                Value = "Land"
            });
            resources.Add(new Resource()
            {
                Label = "home_title",
                Language = "fr",
                Value = "Trouver un club de golf? Nous contactons le proriétaire."
            });
            resources.Add(new Resource()
            {
                Label = "home_title",
                Language = "en",
                Value = "Found a golf club? We contact the owner."
            });
            resources.Add(new Resource()
            {
                Label = "home_title",
                Language = "nl",
                Value = "Een golfclub gevonden? Wij contacteren de eigenaar."
            });

            resources.Add(new Resource()
            {
                Label = "about_title",
                Language = "fr",
                Value = "GOLFLABEL.NET Intro"
            });
            resources.Add(new Resource()
            {
                Label = "about_title",
                Language = "en",
                Value = "GOLFLABEL.NET Intro"
            });
            resources.Add(new Resource()
            {
                Label = "about_title",
                Language = "nl",
                Value = "GOLFLABEL.NET Intro"
            });

           

            resources.Add(new Resource()
            {
                Label = "faq_title",
                Language = "fr",
                Value = "FAQ"
            });
            resources.Add(new Resource()
            {
                Label = "faq_title",
                Language = "en",
                Value = "FAQ"
            });
            resources.Add(new Resource()
            {
                Label = "faq_title",
                Language = "nl",
                Value = "FAQ"
            });

            resources.Add(new Resource()
            {
                Label = "home_body",
                Language = "fr",
                Value = "<h2>Een golfclub gevonden? Wij contacteren de eigenaar.</h2>"+
					"<p>Wel eens een golfclub vergeten op de fairway? … lastig hé!<br />"+
					"Ooit een golfclub gevonden in de rough? … Van wie zou die zijn?<br />"+
					"Jouw teruggevonden club kan nu alvast terugbezorgd worden!<br />"+
					"ALTIJD … EN OVERAL!</p>"+
                    "<p>Kleef een label op elke golfclub uit je set. Dit doe je best net onder de grip, aan de achterzijde van je clubs. Let er wel op dat je shafts zuiver en vetvrij zijn. De labels bereiken hun definitieve kleefkracht na 24 uur.</p>"+
                    "<p>Om de service te activeren dient U slechts de GOLFLABEL.NET-code en uw CONTACTGEGEVENS in te geven.</p>"
            });
            resources.Add(new Resource()
            {
                Label = "home_body",
                Language = "en",
                Value = "<h2>Een golfclub gevonden? Wij contacteren de eigenaar.</h2>" +
                    "<p>Wel eens een golfclub vergeten op de fairway? … lastig hé!<br />" +
                    "Ooit een golfclub gevonden in de rough? … Van wie zou die zijn?<br />" +
                    "Jouw teruggevonden club kan nu alvast terugbezorgd worden!<br />" +
                    "ALTIJD … EN OVERAL!</p>" +
                    "<p>Kleef een label op elke golfclub uit je set. Dit doe je best net onder de grip, aan de achterzijde van je clubs. Let er wel op dat je shafts zuiver en vetvrij zijn. De labels bereiken hun definitieve kleefkracht na 24 uur." +
                    "Om de service te activeren dient U slechts de GOLFLABEL.NET-code en uw CONTACTGEGEVENS in te geven.</p>"
            });
            resources.Add(new Resource()
            {
                Label = "home_body",
                Language = "nl",
                Value = "<h2>Een golfclub gevonden? Wij contacteren de eigenaar.</h2>" +
                    "<p>Wel eens een golfclub vergeten op de fairway? … lastig hé!<br />" +
                    "Ooit een golfclub gevonden in de rough? … Van wie zou die zijn?<br />" +
                    "Jouw teruggevonden club kan nu alvast terugbezorgd worden!<br />" +
                    "ALTIJD … EN OVERAL!</p>" +
                    "<p>Kleef een label op elke golfclub uit je set. Dit doe je best net onder de grip, aan de achterzijde van je clubs. Let er wel op dat je shafts zuiver en vetvrij zijn. De labels bereiken hun definitieve kleefkracht na 24 uur." +
                    "Om de service te activeren dient U slechts de GOLFLABEL.NET-code en uw CONTACTGEGEVENS in te geven.</p>"
            });

            resources.Add(new Resource()
            {
                Label = "activate_link",
                Language = "fr",
                Value = "Activer mes labels"
            });
            resources.Add(new Resource()
            {
                Label = "activate_link",
                Language = "en",
                Value = "Activate my labels"
            });
            resources.Add(new Resource()
            {
                Label = "activate_link",
                Language = "nl",
                Value = "Mijn labels activeren"
            });

            resources.Add(new Resource()
            {
                Label = "profile_link",
                Language = "fr",
                Value = "Modifier mon profil"
            });
            resources.Add(new Resource()
            {
                Label = "profile_link",
                Language = "en",
                Value = "Change my profile"
            });
            resources.Add(new Resource()
            {
                Label = "profile_link",
                Language = "nl",
                Value = "Mijn gegevens wijzigen"
            });

            resources.Add(new Resource()
            {
                Label = "declare_link",
                Language = "fr",
                Value = "Vous avez trouvé un club de Golf?"
            });
            resources.Add(new Resource()
            {
                Label = "declare_link",
                Language = "en",
                Value = "You've found a golf club?"
            });
            resources.Add(new Resource()
            {
                Label = "declare_link",
                Language = "nl",
                Value = "Een golf club gevonden?"
            });

            resources.Add(new Resource()
            {
                Label = "password",
                Language = "fr",
                Value = "Choisissez ici votre mot de passe"
            });
            resources.Add(new Resource()
            {
                Label = "password",
                Language = "en",
                Value = "Choose your password"
            });
            resources.Add(new Resource()
            {
                Label = "password",
                Language = "nl",
                Value = "Kies hier een wachtwoord naar keuze"
            });

            resources.Add(new Resource()
            {
                Label = "confirm_password",
                Language = "fr",
                Value = "Répété le mot de passe"
            });
            resources.Add(new Resource()
            {
                Label = "confirm_password",
                Language = "en",
                Value = "Confirm your password"
            });
            resources.Add(new Resource()
            {
                Label = "confirm_password",
                Language = "nl",
                Value = "Herhaal wachtwoord"
            });

            resources.Add(new Resource()
            {
                Label = "contact_data",
                Language = "fr",
                Value = "Mes donnés de contact"
            });
            resources.Add(new Resource()
            {
                Label = "contact_data",
                Language = "en",
                Value = "My contact info"
            });
            resources.Add(new Resource()
            {
                Label = "contact_data",
                Language = "nl",
                Value = "Mijn contactgegevens"
            });

            resources.Add(new Resource()
            {
                Label = "email2",
                Language = "fr",
                Value = "Deuxième e-mail"
            });
            resources.Add(new Resource()
            {
                Label = "email2",
                Language = "en",
                Value = "Second e-mail"
            });
            resources.Add(new Resource()
            {
                Label = "email2",
                Language = "nl",
                Value = "Tweede e-mail"
            });
            resources.Add(new Resource()
            {
                Label = "confirm_email",
                Language = "fr",
                Value = "Répétez votre e-mail"
            });
            resources.Add(new Resource()
            {
                Label = "confirm_email",
                Language = "en",
                Value = "Confirm your e-mail"
            });
            resources.Add(new Resource()
            {
                Label = "confirm_email",
                Language = "nl",
                Value = "Herhaal je e-mail"
            });
            resources.Add(new Resource()
            {
                Label = "confirm_email2",
                Language = "fr",
                Value = "Répétez votre second e-mail"
            });
            resources.Add(new Resource()
            {
                Label = "confirm_email2",
                Language = "en",
                Value = "Confirm your second e-mail"
            });
            resources.Add(new Resource()
            {
                Label = "confirm_email2",
                Language = "nl",
                Value = "Herhaal je tweede e-mail"
            });

            resources.Add(new Resource()
            {
                Label = "welcome",
                Language = "fr",
                Value = "Bienvenue chez GOLFLABEL.NET"
            });
            resources.Add(new Resource()
            {
                Label = "welcome",
                Language = "en",
                Value = "Welcome at GOLFLABEL.NET"
            });
            resources.Add(new Resource()
            {
                Label = "welcome",
                Language = "nl",
                Value = "Welkom bij GOLFLABEL.NET"
            });

            resources.Add(new Resource()
            {
                Label = "activat_index_body",
                Language = "fr",
                Value = "<p id='activate_body_text'>Kleef een label op elke golfclub uit je set. Dit doe je best net onder de grip, aan de achterzijde van je clubs. " +
                        "Let er wel op dat je shafts zuiver en vetvrij zijn. De labels bereiken hun definitieve kleefkracht na 24 uur.</p>" +
                        "<p id='activatep'>Om de service te activeren dient U slechts de GOLFLABEL.NET-code en uw CONTACTGEGEVENS in te geven.</p>" 
                        
            });
            resources.Add(new Resource()
            {
                Label = "activat_index_body",
                Language = "nl",
                Value = "<p id='activate_body_text'>Kleef een label op elke golfclub uit je set. Dit doe je best net onder de grip, aan de achterzijde van je clubs. " +
                        "Let er wel op dat je shafts zuiver en vetvrij zijn. De labels bereiken hun definitieve kleefkracht na 24 uur.</p>" +
                        "<p id='activatep'>Om de service te activeren dient U slechts de GOLFLABEL.NET-code en uw CONTACTGEGEVENS in te geven.</p>" 
                       
            });
            resources.Add(new Resource()
            {
                Label = "activat_index_body",
                Language = "en",
                Value = "<p id='activate_body_text'>Kleef een label op elke golfclub uit je set. Dit doe je best net onder de grip, aan de achterzijde van je clubs. " +
                        "Let er wel op dat je shafts zuiver en vetvrij zijn. De labels bereiken hun definitieve kleefkracht na 24 uur.</p>" +
                        "<p id='activatep'>Om de service te activeren dient U slechts de GOLFLABEL.NET-code en uw CONTACTGEGEVENS in te geven.</p>" 
                   
            });

            //activate_tip
            resources.Add(new Resource()
            {
                Label = "activate_tip",
                Language = "fr",
                Value = "Vous le toruvez sur le label."
            });
            resources.Add(new Resource()
            {
                Label = "activate_tip",
                Language = "nl",
                Value = "Die vind je op de GOLFLABEL.NET-sticker."
            });
            resources.Add(new Resource()
            {
                Label = "activate_tip",
                Language = "en",
                Value = "You'll find it on the label."
            });

            resources.Add(new Resource()
            {
                Label = "activate_next",
                Language = "fr",
                Value = "Suite vers données personnelles."
            });
            resources.Add(new Resource()
            {
                Label = "activate_next",
                Language = "nl",
                Value = "Geef hierna je contactgegevens in."
            });
            resources.Add(new Resource()
            {
                Label = "activate_next",
                Language = "en",
                Value = "Go to profile info."
            });

            resources.Add(new Resource()
            {
                Label = "err_invalidBadge",
                Language = "fr",
                Value = "Label invalide!"
            });
            resources.Add(new Resource()
            {
                Label = "err_invalidBadge",
                Language = "nl",
                Value = "Ongeldige label!"
            });
            resources.Add(new Resource()
            {
                Label = "err_invalidBadge",
                Language = "en",
                Value = "Invalid label!"
            });

         
            resources.Add(new Resource()
            {
                Label = "men",
                Language = "fr",
                Value = "Monsieur"
            });
            resources.Add(new Resource()
            {
                Label = "men",
                Language = "nl",
                Value = "Mijnheer"
            });
            resources.Add(new Resource()
            {
                Label = "men",
                Language = "en",
                Value = "Mister"
            });

            resources.Add(new Resource()
            {
                Label = "woman",
                Language = "fr",
                Value = "Madame"
            });
            resources.Add(new Resource()
            {
                Label = "woman",
                Language = "nl",
                Value = "Mevrouw"
            });
            resources.Add(new Resource()
            {
                Label = "woman",
                Language = "en",
                Value = "Madam"
            });

            resources.Add(new Resource()
            {
                Label = "mobile_title",
                Language = "fr",
                Value = "Activer le service GOLFLABEL.NET"
            });
            resources.Add(new Resource()
            {
                Label = "mobile_title",
                Language = "nl",
                Value = "Activeren van de GOLFLABEL.NET-service"
            });
            resources.Add(new Resource()
            {
                Label = "mobile_title",
                Language = "en",
                Value = "Activate the GOLFLABEL.NET-service"
            });

            resources.Add(new Resource()
            {
                Label = "woman",
                Language = "fr",
                Value = "Madame"
            });
            resources.Add(new Resource()
            {
                Label = "woman",
                Language = "nl",
                Value = "Mevrouw"
            });
            resources.Add(new Resource()
            {
                Label = "woman",
                Language = "en",
                Value = "Madam"
            });

            resources.Add(new Resource()
            {
                Label = "mobile_nr",
                Language = "fr",
                Value = "Numéro de mobile:"
            });
            resources.Add(new Resource()
            {
                Label = "mobile_nr",
                Language = "nl",
                Value = "Mobiel nummer:"
            });
            resources.Add(new Resource()
            {
                Label = "mobile_nr",
                Language = "en",
                Value = "Mobile number:"
            });

            resources.Add(new Resource()
            {
                Label = "country_code",
                Language = "fr",
                Value = "Prefix pays:"
            });
            resources.Add(new Resource()
            {
                Label = "country_code",
                Language = "nl",
                Value = "Landcode:"
            });
            resources.Add(new Resource()
            {
                Label = "country_code",
                Language = "en",
                Value = "Country code:"
            });

            resources.Add(new Resource()
            {
                Label = "number",
                Language = "fr",
                Value = "Numéro: ex. 475204040"
            });
            resources.Add(new Resource()
            {
                Label = "number",
                Language = "nl",
                Value = "Nummer*: vb. 475204040"
            });
            resources.Add(new Resource()
            {
                Label = "number",
                Language = "en",
                Value = "Number:"
            });

            resources.Add(new Resource()
            {
                Label = "confirm_phone",
                Language = "fr",
                Value = "confirm_phone"
            });
            resources.Add(new Resource()
            {
                Label = "confirm_phone",
                Language = "nl",
                Value = "Bevestig nummer:"
            });
            resources.Add(new Resource()
            {
                Label = "confirm_phone",
                Language = "en",
                Value = "Confirm phone number:"
            });

            resources.Add(new Resource()
            {
                Label = "accept_terms",
                Language = "fr",
                Value = "accept_terms"
            });
            resources.Add(new Resource()
            {
                Label = "accept_terms",
                Language = "nl",
                Value = "Ik heb de Algemene Voorwaarden gelezen en goedgekeurd *"
            });
            resources.Add(new Resource()
            {
                Label = "accept_terms",
                Language = "en",
                Value = "accept_terms"
            });

            resources.Add(new Resource()
            {
                Label = "ready_btn",
                Language = "fr",
                Value = "ready_btn"
            });
            resources.Add(new Resource()
            {
                Label = "ready_btn",
                Language = "nl",
                Value = "KLAAR? KLIL DAN HIER"
            });
            resources.Add(new Resource()
            {
                Label = "ready_btn",
                Language = "en",
                Value = "ready_btn"
            });

            resources.Add(new Resource()
            {
                Label = "operator_country",
                Language = "fr",
                Value = "prefix pays"
            });
            resources.Add(new Resource()
            {
                Label = "operator_country",
                Language = "nl",
                Value = "Land code"
            });
            resources.Add(new Resource()
            {
                Label = "operator_country",
                Language = "en",
                Value = "Country Code"
            });

            resources.Add(new Resource()
            {
                Label = "declare_title",
                Language = "fr",
                Value = "J'ai retrouvé un club de golf !"
            });
            resources.Add(new Resource()
            {
                Label = "declare_title",
                Language = "nl",
                Value = "Ik heb een golfclub gevonden !"
            });
            resources.Add(new Resource()
            {
                Label = "declare_title",
                Language = "en",
                Value = "I've found a golf club !"
            });

            resources.Add(new Resource()
            {
                Label = "declare_body",
                Language = "fr",
                Value = "Le propriétaire peut vous contacter."
            });
            resources.Add(new Resource()
            {
                Label = "declare_body",
                Language = "nl",
                Value = "Zo kan de eigenaar je zelf contacteren om concreet af te spreken of je te bedanken voor je medewerking. Je kan er ook voor kiezen om alleen een boodschap aan de eigenaar te laten.",
            });
            resources.Add(new Resource()
            {
                Label = "declare_body",
                Language = "en",
                Value = "The owner can contact you to get his golf club back."
            });

            //sendmessage_title
            resources.Add(new Resource()
            {
                Label = "sendmessage_title",
                Language = "fr",
                Value = "VOTRE MESSAGE POUR LE PROPRIETAIRE"
            });
            resources.Add(new Resource()
            {
                Label = "sendmessage_title",
                Language = "nl",
                Value = "UW BOODSCHAP VOOR DE EIGENAAR",
            });
            resources.Add(new Resource()
            {
                Label = "sendmessage_title",
                Language = "en",
                Value = "YOUR MESSAGE FOR THE OWNER"
            });

            //sendmessage_legend
            resources.Add(new Resource()
            {
                Label = "sendmessage_legend",
                Language = "fr",
                Value = "Indiquez ici le message pour le proriètaire. Indiquez ci-dessous comment le proriètaire peux vous contacter pour lui rendre son club de golf."
            });
            resources.Add(new Resource()
            {
                Label = "sendmessage_legend",
                Language = "nl",
                Value = "Geef hierna je boodschap in voor de eigenaar. Vermeld hierin zeker waar of hoe de eigenaar zijn/haar golfclub kan ophalen.",
            });
            resources.Add(new Resource()
            {
                Label = "sendmessage_legend",
                Language = "en",
                Value = "Enter here the message for the owner. Mension how the owner can retrieve his golf club."
            });


            //sendmessage_label_sms
            resources.Add(new Resource()
            {
                Label = "sendmessage_sms_label",
                Language = "fr",
                Value = "Le message ci-dessous sera envoyé au propriètaire par sms:"
            });
            resources.Add(new Resource()
            {
                Label = "sendmessage_sms_label",
                Language = "nl",
                Value = "Volgende sms zal verstuurd worden via naar de eigenaar van de golfclub  :",
            });
            resources.Add(new Resource()
            {
                Label = "sendmessage_sms_label",
                Language = "en",
                Value = "This message will be send to the owner through sms:"
            });

            //sendmessage_label_html
            resources.Add(new Resource()
            {
                Label = "sendmessage_mail_label",
                Language = "fr",
                Value = "Le couriel ci-dessous sera envoyé au propriètaire:"
            });
            resources.Add(new Resource()
            {
                Label = "sendmessage_mail_label",
                Language = "nl",
                Value = "Volgende e-mail zal verstuurd worden via naar de eigenaar van de golfclub  :",
            });
            resources.Add(new Resource()
            {
                Label = "sendmessage_mail_label",
                Language = "en",
                Value = "This e-mail will be send to the owner through sms:"
            });


          
            //confirmation_mail_text
            resources.Add(new Resource()
            {
                Label = "confirmation_mail_text",
                Language = "fr",
                Value = "<p>Mail in het frans todo:vertalen!!!</p><p>Beste [firstname]&nbsp;[lastname],</p> " +
                "<p>De code [badge]. werd geactiveerd op [registrationdate].</p>" +
                "<p>De service blijft geactiveerd tot [endvalidity].</p>" +
                "<p>Voor het verstrijken van de servicetermijn zullen we je per e-mail contacteren en je de mogelijkheid bieden de service te verlengen.</p>" +
                "<p>GOLFLABEL.NET zal je per e-mail en sms contacteren als de code van je teruggevonden club wordt ingegeven.</p>" +
                "<p>We wensen je veel golfplezier en hopen je van dienst te kunnen zijn als je je golfclub ooit mocht verliezen.</p>"+
                "<p>We sturen je eveneens een sms op uw opgegeven nummer.</p> " +
                "<p>Zo weet je zeker dat alle gegevens correct werden verwerkt.</p>"+
                "<p>Heb je bijkomende vragen of bemerkingen, contacteer ons dan op:<br/>contact@GOLFLABEL.NET</p>"+
                "<p>Vriendelijke groeten,<br/>Het GOLFLABEL.NET – team</p>"
            });
            resources.Add(new Resource()
            {
                Label = "confirmation_mail_text",
                Language = "nl",
                Value = "<p>Beste [firstname][lastname],</p> " +
                "<p>De code [badge]. werd geactiveerd op [registrationdate].</p>" +
                "<p>De service blijft geactiveerd tot [endvalidity].</p>" +
                "<p>Voor het verstrijken van de servicetermijn zullen we je per e-mail contacteren en je de mogelijkheid bieden de service te verlengen.</p>" +
                "<p>GOLFLABEL.NET zal je per e-mail en sms contacteren als de code van je teruggevonden club wordt ingegeven.</p>" +
                "<p>We wensen je veel golfplezier en hopen je van dienst te kunnen zijn als je je golfclub ooit mocht verliezen.</p>" +
                "<p>We sturen je eveneens een sms op uw opgegeven nummer.</p> " +
                "<p>Zo weet je zeker dat alle gegevens correct werden verwerkt.</p>" +
                "<p>Heb je bijkomende vragen of bemerkingen, contacteer ons dan op:<br/>contact@GOLFLABEL.NET</p>" +
                "<p>Vriendelijke groeten,<br/>Het GOLFLABEL.NET – team</p>"
            });
            resources.Add(new Resource()
            {
                Label = "confirmation_mail_text",
                Language = "en",
                Value = "<p>Good news, you've subscribed.</p><p> Badge:[badge], RegistrationDate:[registrationdate], EndValidity:[endvalidity], </p><p> [message] </p><p> By: [firstname],[lastname],[emailaddress],[mobile] </p><p> GOLFLABEL.NET which you a lot of fun.</p>"
            });

            //confirmation_mail_subject
            resources.Add(new Resource()
            {
                Label = "confirmation_mail_subject",
                Language = "fr",
                Value = "Bonne nouvelle, vous êtes inscrit"
            });
            resources.Add(new Resource()
            {
                Label = "confirmation_mail_subject",
                Language = "nl",
                Value = "PROFICIAT MET DE ACTIVATIE VAN JE GOLFLABEL.NET CODE.",
            });
            resources.Add(new Resource()
            {
                Label = "confirmation_mail_subject",
                Language = "en",
                Value = "Good news, you've subscribed. "
            });

            //confirmation_sms_text
            resources.Add(new Resource()
            {
                Label = "confirmation_sms_text",
                Language = "fr",
                Value = "Bonne nouvelle, vous êtes inscrit Badge:[badge], [firstname],[lastname],[emailaddress],[mobile] \r GOLFLABEL.NET vous souhaite encore beaucoup de plaisir."
            });
            resources.Add(new Resource()
            {
                Label = "confirmation_sms_text",
                Language = "nl",
                Value = "Beste [firstname][lastname],\r" +
                "De code [badge]. werd geactiveerd op [registrationdate] tot [endvalidity]. \r" +
                "Heb je bijkomende vragen of bemerkingen, contacteer ons dan op:contact@GOLFLABEL.NET \r" +
                "MVG, Het GOLFLABEL.NET – team"
            });
            resources.Add(new Resource()
            {
                Label = "confirmation_sms_text",
                Language = "en",
                Value = "Good news, you've subscribed. Badge:[badge] \r [message] \r By: [firstname],[lastname],[emailaddress],[mobile] \r GOLFLABEL.NET which you a lot of fun."
            });

            //confirmation_mail_from
            resources.Add(new Resource()
            {
                Label = "confirmation_mail_from",
                Language = "fr",
                Value = "golflabel@golflabel.net"
            });
            resources.Add(new Resource()
            {
                Label = "confirmation_mail_from",
                Language = "nl",
                Value = "golflabel@golflabel.net",
            });
            resources.Add(new Resource()
            {
                Label = "confirmation_mail_from",
                Language = "en",
                Value = "golflabel@golflabel.net"
            });


            //admin_mail_to
            resources.Add(new Resource()
            {
                Label = "admin_mail_to",
                Language = "fr",
                Value = "admin@golflabel.net"
            });
            resources.Add(new Resource()
            {
                Label = "admin_mail_to",
                Language = "nl",
                Value = "admin@golflabel.net",
            });
            resources.Add(new Resource()
            {
                Label = "admin_mail_to",
                Language = "en",
                Value = "admin@golflabel.net"
            });

            //admin_mail_from
            resources.Add(new Resource()
            {
                Label = "admin_mail_from",
                Language = "fr",
                Value = "golflabel@golflabel.net"
            });
            resources.Add(new Resource()
            {
                Label = "admin_mail_from",
                Language = "nl",
                Value = "golflabel@golflabel.net",
            });
            resources.Add(new Resource()
            {
                Label = "admin_mail_from",
                Language = "en",
                Value = "golflabel@golflabel.net"
            });

            //admin_mail_subject
            resources.Add(new Resource()
            {
                Label = "admin_mail_subject",
                Language = "fr",
                Value = "Un objet est retrouve, declaration id:[id]"
            });
            resources.Add(new Resource()
            {
                Label = "admin_mail_subject",
                Language = "nl",
                Value = "Een voorwerp werd gevonden, declaration id:[id]"
            });
            resources.Add(new Resource()
            {
                Label = "admin_mail_subject",
                Language = "en",
                Value = "An object was retrieved, declaration id:[id]"
            });

            //admin_mail_subject
            resources.Add(new Resource()
            {
                Label = "admin_mail_text",
                Language = "fr",
                Value = "An object was retrieved! [firstname] [lastname] [nbr] [message] [mobile] [emailaddress] [declarationfirstname] [declarationlastname] [id] [declarationphonenumber]"
            });
            resources.Add(new Resource()
            {
                Label = "admin_mail_text",
                Language = "nl",
                Value = "An object was retrieved! [firstname] [lastname] [nbr] [message] [mobile] [emailaddress] [declarationfirstname] [declarationlastname] [id] [declarationphonenumber]"
            });
            resources.Add(new Resource()
            {
                Label = "admin_mail_text",
                Language = "en",
                Value = "An object was retrieved! [firstname] [lastname] [nbr] [message] [mobile] [emailaddress] [declarationfirstname] [declarationlastname] [id] [declarationphonenumber]"
            });

            //owner_mail_from
            resources.Add(new Resource()
            {
                Label = "owner_mail_from",
                Language = "fr",
                Value = "golflabel@golflabel.net"
            });
            resources.Add(new Resource()
            {
                Label = "owner_mail_from",
                Language = "nl",
                Value = "golflabel@golflabel.net"
            });
            resources.Add(new Resource()
            {
                Label = "owner_mail_from",
                Language = "en",
                Value = "golflabel@golflabel.net"
            });

           //owner_mail_subject
            resources.Add(new Resource()
            {
                Label = "owner_mail_subject",
                Language = "fr",
                Value = "Votre objet avec nr [nbr] a été retrouvé!"
            });
            resources.Add(new Resource()
            {
                Label = "owner_mail_subject",
                Language = "nl",
                Value = "Uw voorwerp met nr [nbr] werd terug gevonden!"
            });
            resources.Add(new Resource()
            {
                Label = "owner_mail_subject",
                Language = "en",
                Value = "Your object with nr [nbr] was found!"
            });

            //owner_sms_text
            resources.Add(new Resource()
            {
                Label = "owner_sms_text",
                Language = "fr",
                Value = "[message] <br/> Envoyé par:+[declarationphonenumber]"
            });
            resources.Add(new Resource()
            {
                Label = "owner_sms_text",
                Language = "nl",
                Value = "[message]  <br/> Opgestuurd door:+[declarationphonenumber]"
            });
            resources.Add(new Resource()
            {
                Label = "owner_sms_text",
                Language = "en",
                Value = "[message]  <br/> Sent by:+[declarationphonenumber]"
            });

            //owner_mail_text
            resources.Add(new Resource()
            {
                Label = "owner_mail_text",
                Language = "fr",
                Value = "<html><body><p>Bonjour [firstname] [lastname],</p><p>Votre objet a été retrouvé!</p> <p>L'objet portant le N°:[nbr]</p> <p>La personne qui là retrouvé vous laisse le message suivant:</p><p>[message]</p><p>Le N° de tel du retrouveur:[declarationphonenumber]</p><p>son adresse e-mail:[declarationemailaddress]</p><p>A bientôt Golflabel.Net</p><body></html>"
            });
            resources.Add(new Resource()
            {
                Label = "owner_mail_text",
                Language = "nl",
                Value = "<html><body><p>Goeiendag [firstname] [lastname],</p><p>Uw voorwerp is terug gevonden!</p> <p>L'objet portant le N°:[nbr]</p> <p>La personne qui là retrouvé vous laisse le message suivant:</p><p>[message]</p><p>Le N° de tel du retrouveur:[declarationphonenumber]</p><p>son adresse e-mail:[declarationemailaddress]</p><p>A bientôt Golflabel.Net</p><body></html>"
            });
            resources.Add(new Resource()
            {
                Label = "owner_mail_text",
                Language = "en",
                Value = "<html><body><p>Hello [firstname] [lastname],</p><p>Your object was found back!</p> <p>L'objet portant le N°:[nbr]</p> <p>La personne qui là retrouvé vous laisse le message suivant:</p><p>[message]</p><p>Le N° de tel du retrouveur:[declarationphonenumber]</p><p>son adresse e-mail:[declarationemailaddress]</p><p>A bientôt Golflabel.Net</p><body></html>"
            });

            //declare_confirm_sub_title
            resources.Add(new Resource()
            {
                Label = "declare_confirm_sub_title",
                Language = "fr",
                Value = "MERCI!"
            });
            resources.Add(new Resource()
            {
                Label = "declare_confirm_sub_title",
                Language = "nl",
                Value = "BEDANKT VOOR UW INSPANNING !"
            });
            resources.Add(new Resource()
            {
                Label = "declare_confirm_sub_title",
                Language = "en",
                Value = "THANKS!"
            });

            //declare_confirm_top_text
            resources.Add(new Resource()
            {
                Label = "declare_confirm_top_text",
                Language = "fr",
                Value = "Le message suivant vient d'être envoyé au propriétaire du club de golf:"
            });
            resources.Add(new Resource()
            {
                Label = "declare_confirm_top_text",
                Language = "nl",
                Value = "Volgende boodschap werd verstuurd naar de eigenaar van de golfclub :"
            });
            resources.Add(new Resource()
            {
                Label = "declare_confirm_top_text",
                Language = "en",
                Value = "This message was just send to the owner of the golf stick:"
            });

            //declare_confirm_bottom_text
            resources.Add(new Resource()
            {
                Label = "declare_confirm_bottom_text",
                Language = "fr",
                Value = "Si vous souhaitez profiter vous aussi des avanatages de ce service, consultez la listes des dealers et contactez le club dans votre region."
            });
            resources.Add(new Resource()
            {
                Label = "declare_confirm_bottom_text",
                Language = "nl",
                Value = "Wenst U ook zelf gebruik te maken van deze service, kijk dan op de dealerlijst hieronder en contacteer uw golfshop in uw buurt."
            });
            resources.Add(new Resource()
            {
                Label = "declare_confirm_bottom_text",
                Language = "en",
                Value = "If you want to benefit from the advantages of this service, look at the dealer list here at the bottom and contact the golf club in your region."
            });

            //logon_title
            resources.Add(new Resource()
            {
                Label = "logon_title",
                Language = "fr",
                Value = "Se connecter"
            });
            resources.Add(new Resource()
            {
                Label = "logon_title",
                Language = "nl",
                Value = "Aanmelden"   
            });
            resources.Add(new Resource()
            {
                Label = "logon_title",
                Language = "en",
                Value = "Logon"
            });

            //edit_profile_title
            resources.Add(new Resource()
            {
                Label = "edit_profile_title",
                Language = "fr",
                Value = "Modifier mes données"
            });
            resources.Add(new Resource()
            {
                Label = "edit_profile_title",
                Language = "nl",
                Value = "Mijn gegevens wijzigen"
            });
            resources.Add(new Resource()
            {
                Label = "edit_profile_title",
                Language = "en",
                Value = "Change my data"
            });

            //default_box_text
            resources.Add(new Resource()
            {
                Label = "default_box_text",
                Language = "fr",
                Value = "<p>Trouvez un stick ou enregistrer un nouveau compte <br/> Indiquez le GOLFLABEL.NET CODE ci-dessous:</p>"
            });
            resources.Add(new Resource()
            {
                Label = "default_box_text",
                Language = "nl",
                Value = "<p>Een set gevonden of een nieuwe account aanmaken ? <br /><br />Vul jouw GOLFLABEL.NET CODE hier in:</p>"
            });
            resources.Add(new Resource()
            {
                Label = "default_box_text",
                Language = "en",
                Value = "Found a golf stick or create a new account <br/> Fill the GOLFLABEL.NET CODE here:"
            });

            //edit_profile_box_text
            resources.Add(new Resource()
            {
                Label = "edit_profile_box_text",
                Language = "fr",
                Value = "Modifier les données qui serviront a vous contacter en cas de perte."
            });
            resources.Add(new Resource()
            {
                Label = "edit_profile_box_text",
                Language = "nl",
                Value = "De gegevens wijzigen die zullen dienen om jouw te bereiken."
            });
            resources.Add(new Resource()
            {
                Label = "edit_profile_box_text",
                Language = "en",
                Value = "Change profile data to contact you."
            });

            //edit_profile_box_link
            resources.Add(new Resource()
            {
                Label = "edit_profile_box_link",
                Language = "fr",
                Value = "Mes données"
            });
            resources.Add(new Resource()
            {
                Label = "edit_profile_box_link",
                Language = "nl",
                Value = "Mijn gegevens"
            });
            resources.Add(new Resource()
            {
                Label = "edit_profile_box_link",
                Language = "en",
                Value = "My profile"
            });

            //add_badge_box_text
            resources.Add(new Resource()
            {
                Label = "add_badge_box_text",
                Language = "fr",
                Value = "Ajoute un nouveau label a un compte existant."
            });
            resources.Add(new Resource()
            {
                Label = "add_badge_box_text",
                Language = "nl",
                Value = "Een nieuwe label toevoegen aan mijn profiel."
            });
            resources.Add(new Resource()
            {
                Label = "add_badge_box_text",
                Language = "en",
                Value = "Add a new label to your profile."
            });

            //add_badge_box_link
            resources.Add(new Resource()
            {
                Label = "add_badge_box_link",
                Language = "fr",
                Value = "Ajouter un nouveau label"
            });
            resources.Add(new Resource()
            {
                Label = "add_badge_box_link",
                Language = "nl",
                Value = "Een nieuwe label toevoegen"
            });
            resources.Add(new Resource()
            {
                Label = "add_badge_box_link",
                Language = "en",
                Value = "Add new label"
            });

            //error_login_unsuccessfull
            resources.Add(new Resource()
            {
                Label = "error_login_unsuccessfull",
                Language = "fr",
                Value = "L'authentification a échoué corigez votre N° de badge ou votre mot de passe."
            });
            resources.Add(new Resource()
            {
                Label = "error_login_unsuccessfull",
                Language = "nl",
                Value = "Aanmelden is mislukt, verbeter de label nummer of jouw wachtwoord."
            });
            resources.Add(new Resource()
            {
                Label = "error_login_unsuccessfull",
                Language = "en",
                Value = "Login was unsuccessful. Please correct the errors and try again."
            });

            //login_title
            resources.Add(new Resource()
            {
                Label = "login_title",
                Language = "fr",
                Value = "S'authentifier"
            });
            resources.Add(new Resource()
            {
                Label = "login_title",
                Language = "nl",
                Value = "Aanmelden"
            });
            resources.Add(new Resource()
            {
                Label = "login_title",
                Language = "en",
                Value = "Account information"
            });

            //label_nbr
            resources.Add(new Resource()
            {
                Label = "label_nbr",
                Language = "fr",
                Value = "N° de votre label:"
            });
            resources.Add(new Resource()
            {
                Label = "label_nbr",
                Language = "nl",
                Value = "Label code:"
            });
            resources.Add(new Resource()
                              {
                                  Label = "label_nbr",
                                  Language = "en",
                                  Value = "Label code:"
                              });

            //login_pasword
            resources.Add(new Resource()
            {
                Label = "login_password",
                Language = "fr",
                Value = "Mot de passe:"
            });
            resources.Add(new Resource()
            {
                Label = "login_password",
                Language = "nl",
                Value = "Paswoord:"
            });
            resources.Add(new Resource()
            {
                Label = "login_password",
                Language = "en",
                Value = "Password:"
            });

            //remember_me
            resources.Add(new Resource()
            {
                Label = "remember_me",
                Language = "fr",
                Value = "Souvenez vous de moi"
            });
            resources.Add(new Resource()
            {
                Label = "remember_me",
                Language = "nl",
                Value = "Onthoud mijn gegevens"
            });
            resources.Add(new Resource()
            {
                Label = "remember_me",
                Language = "en",
                Value = "Remember me"
            });

            //err_login
            resources.Add(new Resource()
            {
                Label = "err_login",
                Language = "fr",
                Value = "Mot de passe ou label invalide"
            });
            resources.Add(new Resource()
            {
                Label = "err_login",
                Language = "nl",
                Value = "Passwoord of login is niet geldig"
            });
            resources.Add(new Resource()
            {
                Label = "err_login",
                Language = "en",
                Value = "Password or login incorect"
            });

            //err_label
            resources.Add(new Resource()
            {
                Label = "err_label",
                Language = "fr",
                Value = "label invalide"
            });
            resources.Add(new Resource()
            {
                Label = "err_label",
                Language = "nl",
                Value = "label is niet geldig"
            });
            resources.Add(new Resource()
            {
                Label = "err_label",
                Language = "en",
                Value = "label is incorect"
            });

            //send_password_link
            resources.Add(new Resource()
            {
                Label = "send_password_link",
                Language = "fr",
                Value = "J'ai oublié mon mot de passe, envoyer un nouveau mot de passe!"
            });
            resources.Add(new Resource()
            {
                Label = "send_password_link",
                Language = "nl",
                Value = "Ik ben mijn paswoord vergeten, zend mij een nieuwe paswoord!"
            });
            resources.Add(new Resource()
            {
                Label = "send_password_link",
                Language = "en",
                Value = "I forgot my password, send me a new one!"
            });

            //send_password_mail_body
            resources.Add(new Resource()
            {
                Label = "send_password_mail_body",
                Language = "fr",
                Value = "<p>Votre nouveau mot de passe est:</p><p>[password]</p>"
            });
            resources.Add(new Resource()
            {
                Label = "send_password_mail_body",
                Language = "nl",
                Value = "<p>Uw nieuw paswoord is:</p><p>[password]</p>"
            });
            resources.Add(new Resource()
            {
                Label = "send_password_mail_body",
                Language = "en",
                Value = "<p>Your new pasword is:</p><p>[password]</p>"
            });

            //send_password_mail_subject
            resources.Add(new Resource()
            {
                Label = "send_password_mail_subject",
                Language = "fr",
                Value = "Votre nouveau mot de passe!"
            });
            resources.Add(new Resource()
            {
                Label = "send_password_mail_subject",
                Language = "nl",
                Value = "Uw nieuw paswoord!"
            });
            resources.Add(new Resource()
            {
                Label = "send_password_mail_subject",
                Language = "en",
                Value = "Your new pasword!"
            });

            //send_password_title
            resources.Add(new Resource()
            {
                Label = "send_password_title",
                Language = "fr",
                Value = "Envoyer un nouveau mot de passe!"
            });
            resources.Add(new Resource()
            {
                Label = "send_password_title",
                Language = "nl",
                Value = "Een nieuw paswoord zenden!"
            });
            resources.Add(new Resource()
            {
                Label = "send_password_title",
                Language = "en",
                Value = "Send a new pasword!"
            });

            //send_password_confirmation
            resources.Add(new Resource()
            {
                Label = "send_password_confirmation",
                Language = "fr",
                Value = "Un nouveau mot de passe vient d'être envoyé!"
            });
            resources.Add(new Resource()
            {
                Label = "send_password_confirmation",
                Language = "nl",
                Value = "Een nieuw paswoord werd zonet gezonden!"
            });
            resources.Add(new Resource()
            {
                Label = "send_password_confirmation",
                Language = "en",
                Value = "A new password was send to you!"
            });

            //activate_account_link
            resources.Add(new Resource()
            {
                Label = "activate_account_link",
                Language = "fr",
                Value = "Pas encore inscrit, créer un nouveau compte ici!"
            });
            resources.Add(new Resource()
            {
                Label = "activate_account_link",
                Language = "nl",
                Value = "Nog niet ingeschreven, maak een nieuw profiel aan!"
            });
            resources.Add(new Resource()
            {
                Label = "activate_account_link",
                Language = "en",
                Value = "Not yet subscribed! Create a ne account here!"
            });

            //enter_label_text
            resources.Add(new Resource()
            {
                Label = "enter_label_text",
                Language = "fr",
                Value = "Indiquez ici votre N° de label:"
            });
            resources.Add(new Resource()
            {
                Label = "enter_label_text",
                Language = "nl",
                Value = "Vul hier jouw label in:"
            });
            resources.Add(new Resource()
            {
                Label = "enter_label_text",
                Language = "en",
                Value = "Fill-in your label here:"
            });

            //edit_owner_confirm
            resources.Add(new Resource()
            {
                Label = "edit_owner_confirm",
                Language = "fr",
                Value = "Vos données ont bien été enregistrées!"
            });
            resources.Add(new Resource()
            {
                Label = "edit_owner_confirm",
                Language = "nl",
                Value = "Uw gegevens werden opgeslagen!"
            });
            resources.Add(new Resource()
            {
                Label = "edit_owner_confirm",
                Language = "en",
                Value = "Your changes were saved!"
            });

            //your_badge_nbrs
            resources.Add(new Resource()
            {
                Label = "your_badge_nbrs",
                Language = "fr",
                Value = "Vos golf label:"
            });
            resources.Add(new Resource()
            {
                Label = "your_badge_nbrs",
                Language = "nl",
                Value = "Jouw golf labels:"
            });
            resources.Add(new Resource()
            {
                Label = "your_badge_nbrs",
                Language = "en",
                Value = "Your golf labels:"
            });

            //new_badge
            resources.Add(new Resource()
            {
                Label = "new_badge",
                Language = "fr",
                Value = "Nouveau golf label:"
            });
            resources.Add(new Resource()
            {
                Label = "new_badge",
                Language = "nl",
                Value = "Nieuw golf label:"
            });
            resources.Add(new Resource()
            {
                Label = "new_badge",
                Language = "en",
                Value = "New golf label:"
            });

            //add_badge_title
            resources.Add(new Resource()
            {
                Label = "add_badge_title",
                Language = "fr",
                Value = "Ajouter un Golf Label à votre compte"
            });
            resources.Add(new Resource()
            {
                Label = "add_badge_title",
                Language = "nl",
                Value = "Voeg een Golf Label toe"
            });
            resources.Add(new Resource()
            {
                Label = "add_badge_title",
                Language = "en",
                Value = "Add a new Golf Label"
            });


            //err_latest_label
            resources.Add(new Resource()
            {
                Label = "err_latest_label",
                Language = "fr",
                Value = "Il doit y avoir au moins un label actif dans votre compte.  Si vous désirez effacer aussi ce label choisisez effacer compte dans la page modification!"
            });
            resources.Add(new Resource()
            {
                Label = "err_latest_label",
                Language = "nl",
                Value = "Er moet minstens 1 label actief zijn per profiel, indien je wenst deze label te verwijderen kun je de optie mijn profiel verwijderen"
            });
            resources.Add(new Resource()
            {
                Label = "err_latest_label",
                Language = "en",
                Value = "You need at least 1 actif label into your account. If you wich to remove this label, choose the option delete my account"
            });

            //logon
            resources.Add(new Resource()
            {
                Label = "logon",
                Language = "fr",
                Value = "S'authentifier"
            });
            resources.Add(new Resource()
            {
                Label = "logon",
                Language = "nl",
                Value = "Aanmelden"
            });
            resources.Add(new Resource()
            {
                Label = "logon",
                Language = "en",
                Value = "LogOn"
            });

            //delete_accout_title
            resources.Add(new Resource()
            {
                Label = "delete_account_title",
                Language = "fr",
                Value = "Effacer toutes mes données"
            });
            resources.Add(new Resource()
            {
                Label = "delete_account_title",
                Language = "nl",
                Value = "Al mijn gegevens verwijderen"
            });
            resources.Add(new Resource()
            {
                Label = "delete_account_title",
                Language = "en",
                Value = "Delete my account"
            });

            //cancel
            resources.Add(new Resource()
            {
                Label = "cancel",
                Language = "fr",
                Value = "Annuler"
            });
            resources.Add(new Resource()
            {
                Label = "cancel",
                Language = "nl",
                Value = "Annuleren"
            });
            resources.Add(new Resource()
            {
                Label = "cancel",
                Language = "en",
                Value = "Cancel"
            });

            //delete_account_text
            resources.Add(new Resource()
            {
                Label = "delete_account_text",
                Language = "fr",
                Value = "Etes-vous sure de vouloir effacer toutes vos données?"
            });
            resources.Add(new Resource()
            {
                Label = "delete_account_text",
                Language = "nl",
                Value = "Ben je zeker dat je uw profiel wilt verwijderen?"
            });
            resources.Add(new Resource()
            {
                Label = "delete_account_text",
                Language = "en",
                Value = "Are you sure that you want to delete your account?"
            });

            //change_password_confirm
            resources.Add(new Resource()
            {
                Label = "change_password_confirm",
                Language = "fr",
                Value = "Votre mot de passe vient d'être modifié"
            });
            resources.Add(new Resource()
            {
                Label = "change_password_confirm",
                Language = "nl",
                Value = "Jouw wachtwoord werd aangepast"
            });
            resources.Add(new Resource()
            {
                Label = "change_password_confirm",
                Language = "en",
                Value = "Your password was changed"
            });

            //change_password_title
            resources.Add(new Resource()
            {
                Label = "change_password_title",
                Language = "fr",
                Value = "Modifier mon mot de passe"
            });
            resources.Add(new Resource()
            {
                Label = "change_password_title",
                Language = "nl",
                Value = "Mijn wachtwoord aanpassen"
            });
            resources.Add(new Resource()
            {
                Label = "change_password_title",
                Language = "en",
                Value = "Change my password"
            });

            //old_password
            resources.Add(new Resource()
            {
                Label = "old_password",
                Language = "fr",
                Value = "Mot de passe actuel:"
            });
            resources.Add(new Resource()
            {
                Label = "old_password",
                Language = "nl",
                Value = "Huidig wachtwoord:"
            });
            resources.Add(new Resource()
            {
                Label = "old_password",
                Language = "en",
                Value = "Old password:"
            });

            //new_password
            resources.Add(new Resource()
            {
                Label = "new_password",
                Language = "fr",
                Value = "Nouveaux mot de passe:"
            });
            resources.Add(new Resource()
            {
                Label = "new_password",
                Language = "nl",
                Value = "Nieuw paswoord:"
            });
            resources.Add(new Resource()
            {
                Label = "new_password",
                Language = "en",
                Value = "New password:"
            });

            //password_error
            resources.Add(new Resource()
            {
                Label = "password_error",
                Language = "fr",
                Value = "Le mot de passe doit contenir au moins 5 charachtères!"
            });
            resources.Add(new Resource()
            {
                Label = "password_error",
                Language = "nl",
                Value = "Het paswoord moet minstens 5 charachters tellen"
            });
            resources.Add(new Resource()
            {
                Label = "password_error",
                Language = "en",
                Value = "Password should contain at least 5 chars!"
            });

            //password_confirm_error
            resources.Add(new Resource()
            {
                Label = "password_confirm_error",
                Language = "fr",
                Value = "Les mot de passe sont differents!"
            });
            resources.Add(new Resource()
            {
                Label = "password_confirm_error",
                Language = "nl",
                Value = "Wachtwoorden zijn verschillend!"
            });
            resources.Add(new Resource()
            {
                Label = "password_confirm_error",
                Language = "en",
                Value = "Passwords should be the same!"
            });

            //err_accept_Terms
            resources.Add(new Resource()
            {
                Label = "err_accept_Terms",
                Language = "fr",
                Value = "Vous devez accepter les conditions!"
            });
            resources.Add(new Resource()
            {
                Label = "err_accept_Terms",
                Language = "nl",
                Value = "Je moet de voorwaarden goedkeuren!"
            });
            resources.Add(new Resource()
            {
                Label = "err_accept_Terms",
                Language = "en",
                Value = "You need to accept the terms and conditions!"
            });

            //err_invalid_email
            resources.Add(new Resource()
            {
                Label = "err_email",
                Language = "fr",
                Value = "e-mail est obligatoire est dois contenire une adresse valide!"
            });
            resources.Add(new Resource()
            {
                Label = "err_email",
                Language = "nl",
                Value = "e-mail is verplicht en moet aan geldig e-mail adres bevatten!"
            });
            resources.Add(new Resource()
            {
                Label = "err_email",
                Language = "en",
                Value = "e-mail is mandatory and should contain valid e-mail adress!"
            });

            //err_email_notsame
            resources.Add(new Resource()
            {
                Label = "err_email_notsame",
                Language = "fr",
                Value = "Les e-mail doivent être pareille!"
            });
            resources.Add(new Resource()
            {
                Label = "err_email_notsame",
                Language = "nl",
                Value = "De e-mail moeten dezelfde zijn!"
            });
            resources.Add(new Resource()
            {
                Label = "err_email_notsame",
                Language = "en",
                Value = "e-mail should be equal!"
            });

            //err_wrong_oldpassword
            resources.Add(new Resource()
            {
                Label = "err_wrong_oldpassword",
                Language = "fr",
                Value = "Le mot de passe ne corespond pas!!"
            });
            resources.Add(new Resource()
            {
                Label = "err_wrong_oldpassword",
                Language = "nl",
                Value = "Oud wachtwoord stemt niet overeen!"
            });
            resources.Add(new Resource()
            {
                Label = "err_wrong_oldpassword",
                Language = "en",
                Value = "Oud passwoord komt niet overeen!"
            });

            //password_changed
            resources.Add(new Resource()
            {
                Label = "password_changed",
                Language = "fr",
                Value = "Le mot de passe a été modifié"
            });
            resources.Add(new Resource()
            {
                Label = "password_changed",
                Language = "nl",
                Value = "Het wachtwoord werd veranderd"
            });
            resources.Add(new Resource()
            {
                Label = "password_changed",
                Language = "en",
                Value = "Pasword has been changed"
            });

            //faq_list
            resources.Add(new Resource()
            {
                Label = "faq_list",
                Language = "fr",
                Value = "<li><a href='#' title='#'>Hoe lang blijft de GOLFLABEL.NET-service actief?</a></li>"+
						"<li><a href='#' title='#'>Hoe krijg ik mijn gevonden club terug ?</a></li>"+
						"<li><a href='#' title='#'>Beschermt GOLFLABEL.NET uw clubs tegen diefstal?</a></li>"+
						"<li><a href='#' title='#'>Waarom heb ik een wachtwoord nodig ?</a></li>"+
						"<li><a href='#' title='#'>Hoe kan ik mijn persoonlijke gegevens wijzigen?</a></li>"+
						"<li><a href='#' title='#'>Kan ik mijn gegevens verwijderen?</a></li>"+
						"<li><a href='#' title='#'>Worden mijn persoonlijke gegevens beschermd?</a></li>"+
						"<li><a href='#' title='#'>Biedt GOLFLABEL.NET een internationale service?</a></li>"+
						"<li><a href='#' title='#'>Wat doe ik als ik een gelabelde club vind?</a></li>"+
						"<li><a href='#' title='#'>Waarom staat er een matrix-code op de labels?</a></li>"+
						"<li><a href='#' title='#'>Andere vragen?</a></li>"
            });
            resources.Add(new Resource()
            {
                Label = "faq_list",
                Language = "nl",
                Value =  "<li><a href='#' title='#'>Hoe lang blijft de GOLFLABEL.NET-service actief?</a></li>"+
						"<li><a href='#' title='#'>Hoe krijg ik mijn gevonden club terug ?</a></li>"+
						"<li><a href='#' title='#'>Beschermt GOLFLABEL.NET uw clubs tegen diefstal?</a></li>"+
						"<li><a href='#' title='#'>Waarom heb ik een wachtwoord nodig ?</a></li>"+
						"<li><a href='#' title='#'>Hoe kan ik mijn persoonlijke gegevens wijzigen?</a></li>"+
						"<li><a href='#' title='#'>Kan ik mijn gegevens verwijderen?</a></li>"+
						"<li><a href='#' title='#'>Worden mijn persoonlijke gegevens beschermd?</a></li>"+
						"<li><a href='#' title='#'>Biedt GOLFLABEL.NET een internationale service?</a></li>"+
						"<li><a href='#' title='#'>Wat doe ik als ik een gelabelde club vind?</a></li>"+
						"<li><a href='#' title='#'>Waarom staat er een matrix-code op de labels?</a></li>"+
						"<li><a href='#' title='#'>Andere vragen?</a></li>"
            });
            resources.Add(new Resource()
            {
                Label = "faq_list",
                Language = "en",
                Value = "<li><a href='#' title='#'>Hoe lang blijft de GOLFLABEL.NET-service actief?</a></li>" +
                        "<li><a href='#' title='#'>Hoe krijg ik mijn gevonden club terug ?</a></li>" +
                        "<li><a href='#' title='#'>Beschermt GOLFLABEL.NET uw clubs tegen diefstal?</a></li>" +
                        "<li><a href='#' title='#'>Waarom heb ik een wachtwoord nodig ?</a></li>" +
                        "<li><a href='#' title='#'>Hoe kan ik mijn persoonlijke gegevens wijzigen?</a></li>" +
                        "<li><a href='#' title='#'>Kan ik mijn gegevens verwijderen?</a></li>" +
                        "<li><a href='#' title='#'>Worden mijn persoonlijke gegevens beschermd?</a></li>" +
                        "<li><a href='#' title='#'>Biedt GOLFLABEL.NET een internationale service?</a></li>" +
                        "<li><a href='#' title='#'>Wat doe ik als ik een gelabelde club vind?</a></li>" +
                        "<li><a href='#' title='#'>Waarom staat er een matrix-code op de labels?</a></li>" +
                        "<li><a href='#' title='#'>Andere vragen?</a></li>"
            });

            //faq_body
            resources.Add(new Resource()
            {
                Label = "faq_body",
                Language = "fr",
                Value = "<h2>Hoelang blijft de GOLFLABEL.NET service actief?</h2>"+
						"<p>Na het ingeven van de code, die je op de GOLFLABEL.NET-stickers vindt, en je contactgegevens op onze website, blijft de GOLFLABEL.NET service drie jaar geactiveerd.</p>"+
                        "<p>Binnen deze periode kan je zes maal beroep doen op onze sms en e-mail service om je te contacteren in geval van een teruggevonden golfclub.</p>"+
                        "<p>Hierna, of na het derde jaar, vragen we een kleine bijdrage om de service te verlengen. Op dit ogenblik vragen wij hiervoor een bijdrage van 4 euro per jaar verlenging, twee maal sms en e-mailservice inbegrepen.</p>"+
                        "<p>Betaling om de service te verlengen gebeurt langs de website via kredietkaart of via andere, op de site aangegeven wijze. </p>"+
                        "<p>Zo bepaalt je zelf of je nog langer van deze dienst gebruik wenst te maken.</p>"+
                        "<p>Voorafgaand aan het vervallen van elke serviceperiode wordt de eigenaar* (*de persoon tot wie de contactgegevens behoren) per e-mail op de hoogte gebracht.  Als de eigenaar* niet over een e-mailadres beschikt, kan GOLFLABEL.NET hem niet waarschuwen. </p>"
            });
            resources.Add(new Resource()
            {
                Label = "faq_body",
                Language = "nl",
                Value = "<h2>Hoelang blijft de GOLFLABEL.NET service actief?</h2>" +
                      "<p>Na het ingeven van de code, die je op de GOLFLABEL.NET-stickers vindt, en je contactgegevens op onze website, blijft de GOLFLABEL.NET service drie jaar geactiveerd.</p>" +
                      "<p>Binnen deze periode kan je zes maal beroep doen op onze sms en e-mail service om je te contacteren in geval van een teruggevonden golfclub.</p>" +
                      "<p>Hierna, of na het derde jaar, vragen we een kleine bijdrage om de service te verlengen. Op dit ogenblik vragen wij hiervoor een bijdrage van 4 euro per jaar verlenging, twee maal sms en e-mailservice inbegrepen.</p>" +
                      "<p>Betaling om de service te verlengen gebeurt langs de website via kredietkaart of via andere, op de site aangegeven wijze. </p>" +
                      "<p>Zo bepaalt je zelf of je nog langer van deze dienst gebruik wenst te maken.</p>" +
                      "<p>Voorafgaand aan het vervallen van elke serviceperiode wordt de eigenaar* (*de persoon tot wie de contactgegevens behoren) per e-mail op de hoogte gebracht.  Als de eigenaar* niet over een e-mailadres beschikt, kan GOLFLABEL.NET hem niet waarschuwen. </p>"
            });
            resources.Add(new Resource()
            {
                Label = "faq_body",
                Language = "en",
                Value = "<h2>Hoelang blijft de GOLFLABEL.NET service actief?</h2>" +
                       "<p>Na het ingeven van de code, die je op de GOLFLABEL.NET-stickers vindt, en je contactgegevens op onze website, blijft de GOLFLABEL.NET service drie jaar geactiveerd.</p>" +
                       "<p>Binnen deze periode kan je zes maal beroep doen op onze sms en e-mail service om je te contacteren in geval van een teruggevonden golfclub.</p>" +
                       "<p>Hierna, of na het derde jaar, vragen we een kleine bijdrage om de service te verlengen. Op dit ogenblik vragen wij hiervoor een bijdrage van 4 euro per jaar verlenging, twee maal sms en e-mailservice inbegrepen.</p>" +
                       "<p>Betaling om de service te verlengen gebeurt langs de website via kredietkaart of via andere, op de site aangegeven wijze. </p>" +
                       "<p>Zo bepaalt je zelf of je nog langer van deze dienst gebruik wenst te maken.</p>" +
                       "<p>Voorafgaand aan het vervallen van elke serviceperiode wordt de eigenaar* (*de persoon tot wie de contactgegevens behoren) per e-mail op de hoogte gebracht.  Als de eigenaar* niet over een e-mailadres beschikt, kan GOLFLABEL.NET hem niet waarschuwen. </p>"
            });

            //about_body
            resources.Add(new Resource()
            {
                Label = "about_body",
                Language = "fr",
                Value = "Input here the about_body!"
            });
            resources.Add(new Resource()
            {
                Label = "about_body",
                Language = "nl",
                Value = "Input here the about_body!"
            });
            resources.Add(new Resource()
            {
                Label = "about_body",
                Language = "en",
                Value = "Input here the about_body!"
            });

            //Who title
            resources.Add(new Resource()
            {
                Label = "who_title",
                Language = "fr",
                Value = "Qui sommes nous?"
            });
            resources.Add(new Resource()
            {
                Label = "who_title",
                Language = "en",
                Value = "Who are we"
            });
            resources.Add(new Resource()
            {
                Label = "who_title",
                Language = "nl",
                Value = "wie zijn wij?"
            });

            //who_body
            resources.Add(new Resource()
            {
                Label = "who_body",
                Language = "fr",
                Value = "Input here the who_body!"
            });
            resources.Add(new Resource()
            {
                Label = "who_body",
                Language = "nl",
                Value = "Input here the about_body!"
            });
            resources.Add(new Resource()
            {
                Label = "who_body",
                Language = "en",
                Value = "Input here the about_body!"
            });

            //privacy_title
            resources.Add(new Resource()
            {
                Label = "privacy_title",
                Language = "fr",
                Value = "Vie privée"
            });
            resources.Add(new Resource()
            {
                Label = "privacy_title",
                Language = "nl",
                Value = "Privacybeleid"
            });
            resources.Add(new Resource()
            {
                Label = "privacy_title",
                Language = "en",
                Value = "Privacy"
            });

            //conditions_title
            resources.Add(new Resource()
            {
                Label = "conditions_title",
                Language = "fr",
                Value = "Condition Général"
            });
            resources.Add(new Resource()
            {
                Label = "conditions_title",
                Language = "nl",
                Value = "Algemene voorwaarden"
            });
            resources.Add(new Resource()
            {
                Label = "conditions_title",
                Language = "en",
                Value = "Terms"
            });

            //dealers_title
            resources.Add(new Resource()
            {
                Label = "dealers_title",
                Language = "fr",
                Value = "Listes des dealers"
            });
            resources.Add(new Resource()
            {
                Label = "dealers_title",
                Language = "nl",
                Value = "Dealerlijst"
            });
            resources.Add(new Resource()
            {
                Label = "dealers_title",
                Language = "en",
                Value = "Dealer list"
            });

            //privacy_body
            resources.Add(new Resource()
            {
                Label = "privacy_body",
                Language = "fr",
                Value = "Vie privée"
            });
            resources.Add(new Resource()
            {
                Label = "privacy_body",
                Language = "nl",
                Value = "Privacybeleid"
            });
            resources.Add(new Resource()
            {
                Label = "privacy_body",
                Language = "en",
                Value = "Privacy"
            });

            //conditions_body
            resources.Add(new Resource()
            {
                Label = "conditions_body",
                Language = "fr",
                Value = "Condition Général"
            });
            resources.Add(new Resource()
            {
                Label = "conditions_body",
                Language = "nl",
                Value = "Algemene voorwaarden"
            });
            resources.Add(new Resource()
            {
                Label = "conditions_body",
                Language = "en",
                Value = "Terms"
            });

            //dealers_body
            resources.Add(new Resource()
            {
                Label = "dealers_body",
                Language = "fr",
                Value = "Listes des dealers"
            });
            resources.Add(new Resource()
            {
                Label = "dealers_body",
                Language = "nl",
                Value = "Dealerlijst"
            });
            resources.Add(new Resource()
            {
                Label = "dealers_body",
                Language = "en",
                Value = "Dealer list"
            });

            //contact_title
            resources.Add(new Resource()
            {
                Label = "contact_title",
                Language = "fr",
                Value = "Contact"
            });
            resources.Add(new Resource()
            {
                Label = "contact_title",
                Language = "nl",
                Value = "Contact"
            });
            resources.Add(new Resource()
            {
                Label = "contact_title",
                Language = "en",
                Value = "Contact"
            });

            //contact_body
            resources.Add(new Resource()
            {
                Label = "contact_body",
                Language = "fr",
                Value = "Contact"
            });
            resources.Add(new Resource()
            {
                Label = "contact_body",
                Language = "nl",
                Value = "Contact"
            });
            resources.Add(new Resource()
            {
                Label = "contact_body",
                Language = "en",
                Value = "Contact"
            });

            //terms_title
            resources.Add(new Resource()
            {
                Label = "terms_title",
                Language = "fr",
                Value = "Contact"
            });
            resources.Add(new Resource()
            {
                Label = "terms_title",
                Language = "nl",
                Value = "Contact"
            });
            resources.Add(new Resource()
            {
                Label = "terms_title",
                Language = "en",
                Value = "Contact"
            });

            //terms_body
            resources.Add(new Resource()
            {
                Label = "terms_body",
                Language = "fr",
                Value = "Contact"
            });
            resources.Add(new Resource()
            {
                Label = "terms_body",
                Language = "nl",
                Value = "Contact"
            });
            resources.Add(new Resource()
            {
                Label = "terms_body",
                Language = "en",
                Value = "Contact"
            });

            //locked_ip
            resources.Add(new Resource()
            {
                Label = "locked_ip",
                Language = "fr",
                Value = "Vous avez été bloquer pour tentative de fraude!"
            });
            resources.Add(new Resource()
            {
                Label = "locked_ip",
                Language = "nl",
                Value = "U bent tegengehouden voor het trachten de service te kraken!"
            });
            resources.Add(new Resource()
            {
                Label = "locked_ip",
                Language = "en",
                Value = "You are locked done for trying to hack this service!"
            });

            //confirm_title
            resources.Add(new Resource()
            {
                Label = "confirm_title",
                Language = "fr",
                Value = "Confirmation d'activation"
            });
            resources.Add(new Resource()
            {
                Label = "confirm_title",
                Language = "nl",
                Value = "Bevestiging van activatie"
            });
            resources.Add(new Resource()
            {
                Label = "confirm_title",
                Language = "en",
                Value = "Activation confirmation"
            });

            //mobile_other_nr
            resources.Add(new Resource()
            {
                Label = "mobile_other_nr",
                Language = "fr",
                Value = "Deuxième nummero (optionel):"
            });
            resources.Add(new Resource()
            {
                Label = "mobile_other_nr",
                Language = "nl",
                Value = "Andere mobiel nummer (optioneel):"
            });
            resources.Add(new Resource()
            {
                Label = "mobile_other_nr",
                Language = "en",
                Value = "Other mobile (optional):"
            });

            return resources;
        }

        protected override IEnumerable<BA.MultiMvc.Framework.NHibernate.Resource> GetResources()
        {
            return CreateResources();
        }
    }
}
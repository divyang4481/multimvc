using System.Collections.Generic;
using BA.MultiMvc.Framework.NHibernate;
using NHibernate;

namespace BackToOwner.Web.Setup
{
    public class BicycleResourceCreation : NHResourceCreation
    {
        public BicycleResourceCreation(ISession currentSession):base(currentSession)
        {}

       
        protected override IEnumerable<BA.MultiMvc.Framework.NHibernate.Resource> GetResources()
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
                                  Value = "Champ obligatoire"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "err_required",
                                  Language = "nl",
                                  Value = "Verplichte veld"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "err_required",
                                  Language = "en",
                                  Value = "Required field"
                              });
           
            resources.Add(new Resource()
                              {
                                  Label = "activate_title",
                                  Language = "fr",
                                  Value = "Activez le service BicycleLABEL.NET"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "activate_title",
                                  Language = "en",
                                  Value = "Activate the service BicycleLABEL.NET"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "activate_title",
                                  Language = "nl",
                                  Value = "Activeren van de BicycleLABEL.NET service"
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
                                  Value = "Sex"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "gender",
                                  Language = "en",
                                  Value = "Gender"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "gender",
                                  Language = "nl",
                                  Value = "Sex"
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
                                  Value = "Trouver un Fiets de Bicycle? Nous contactons le proriétaire."
                              });
            resources.Add(new Resource()
                              {
                                  Label = "home_title",
                                  Language = "en",
                                  Value = "Found a Bicycle Fiets? We contact the owner."
                              });
            resources.Add(new Resource()
                              {
                                  Label = "home_title",
                                  Language = "nl",
                                  Value = "Een BicycleFiets gevonden? Wij contacteren de eigenaar."
                              });

            resources.Add(new Resource()
                              {
                                  Label = "about_title",
                                  Language = "fr",
                                  Value = "BicycleLABEL.NET Intro"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "about_title",
                                  Language = "en",
                                  Value = "BicycleLABEL.NET Intro"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "about_title",
                                  Language = "nl",
                                  Value = "BicycleLABEL.NET Intro"
                              });

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
                                  Value = "about"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "who_title",
                                  Language = "nl",
                                  Value = "wie zijn wij?"
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
                                  Value = "Wel eens een BicycleFiets vergeten op de fairway? … lastig hé !" +
                                          "<br/>Ooit een BicycleFiets gevonden in de rough? … Van wie zou die zijn ?"+
                                          "<br/>Jouw teruggevonden Fiets kan nu alvast terugbezorgd worden !" +
                                          "<p>ALTIJD … EN OVERAL</p>"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "home_body",
                                  Language = "en",
                                  Value = "<p>Wel eens een BicycleFiets vergeten op de fairway? … lastig hé !" +
                                          "<br/>Ooit een BicycleFiets gevonden in de rough? … Van wie zou die zijn ?" +
                                          "<br/>Jouw teruggevonden Fiets kan nu alvast terugbezorgd worden !</p>" +
                                          "<p>ALTIJD … EN OVERAL</p>"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "home_body",
                                  Language = "nl",
                                  Value = "<p>Wel eens een BicycleFiets vergeten op de fairway? … lastig hé !" +
                                          "<br/>Ooit een BicycleFiets gevonden in de rough? … Van wie zou die zijn ?" +
                                          "<br/>Jouw teruggevonden Fiets kan nu alvast terugbezorgd worden !</p>" +
                                          "<p>ALTIJD … EN OVERAL</p>"
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
                                  Value = "Vous avez trouvé un Fiets de Bicycle?"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "declare_link",
                                  Language = "en",
                                  Value = "You've found a Bicycle Fiets?"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "declare_link",
                                  Language = "nl",
                                  Value = "Een Bicycle Fiets gevonden?"
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
                                  Value = "Répété ici le mot de passe choisi"
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
                                  Value = "Herhaal hier je gekozen wachtwoord"
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
                                  Value = "Deuxième adresse e-mail (si souhaitez)"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "email2",
                                  Language = "en",
                                  Value = "Second e-mail (non mandatory)"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "email2",
                                  Language = "nl",
                                  Value = "Tweede e-mail (indien gewenst)"
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
                                  Value = "Bienvenue chez BicycleLABEL.NET"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "welcome",
                                  Language = "en",
                                  Value = "Welcome at BicycleLABEL.NET"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "welcome",
                                  Language = "nl",
                                  Value = "Welkom bij BicycleLABEL.NET"
                              });

            resources.Add(new Resource()
                              {
                                  Label = "activat_index_body",
                                  Language = "fr",
                                  Value = "<p id='activate_body_text'>Kleef een label op elke BicycleFiets uit je set. Dit doe je best net onder de grip, aan de achterzijde van je Fietss. " +
                                          "Let er wel op dat je shafts zuiver en vetvrij zijn. De labels bereiken hun definitieve kleefkracht na 24 uur.</p>" +
                                          "<p id='activatep'>Om de service te activeren dient U slechts de BicycleLABEL.NET-code en uw CONTACTGEGEVENS in te geven.</p>" +
                                          "<p id='activate_index_label'>DE BicycleLABEL.NET – code:</p>" 
                              });
            resources.Add(new Resource()
                              {
                                  Label = "activat_index_body",
                                  Language = "nl",
                                  Value = "<p id='activate_body_text'>Kleef een label op elke BicycleFiets uit je set. Dit doe je best net onder de grip, aan de achterzijde van je Fietss. " +
                                          "Let er wel op dat je shafts zuiver en vetvrij zijn. De labels bereiken hun definitieve kleefkracht na 24 uur.</p>" +
                                          "<p id='activatep'>Om de service te activeren dient U slechts de BicycleLABEL.NET-code en uw CONTACTGEGEVENS in te geven.</p>" +
                                          "<p id='activate_index_label'>DE BicycleLABEL.NET – code:</p>" 
                              });
            resources.Add(new Resource()
                              {
                                  Label = "activat_index_body",
                                  Language = "en",
                                  Value = "<p id='activate_body_text'>Kleef een label op elke BicycleFiets uit je set. Dit doe je best net onder de grip, aan de achterzijde van je Fietss. " +
                                          "Let er wel op dat je shafts zuiver en vetvrij zijn. De labels bereiken hun definitieve kleefkracht na 24 uur.</p>" +
                                          "<p id='activatep'>Om de service te activeren dient U slechts de BicycleLABEL.NET-code en uw CONTACTGEGEVENS in te geven.</p>" +
                                          "<p id='activate_index_label'>DE BicycleLABEL.NET – code:</p>" 
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
                                  Label = "activate_tip",
                                  Language = "fr",
                                  Value = "Vous le toruvez sur le label."
                              });
            resources.Add(new Resource()
                              {
                                  Label = "activate_tip",
                                  Language = "nl",
                                  Value = "Die vind je op de BicycleLABEL.NET-sticker."
                              });
            resources.Add(new Resource()
                              {
                                  Label = "activate_tip",
                                  Language = "en",
                                  Value = "You'll find it on the label."
                              });

            resources.Add(new Resource()
                              {
                                  Label = "men",
                                  Language = "fr",
                                  Value = "Homme"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "men",
                                  Language = "nl",
                                  Value = "Man"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "men",
                                  Language = "en",
                                  Value = "Men"
                              });

            resources.Add(new Resource()
                              {
                                  Label = "woman",
                                  Language = "fr",
                                  Value = "Femme"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "woman",
                                  Language = "nl",
                                  Value = "Vrouw"
                              });
            resources.Add(new Resource()
                              {
                                  Label = "woman",
                                  Language = "en",
                                  Value = "Woman"
                              });

            return resources;
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLinq {
    public class Donnees {
        public List<Auteur> ListeAuteurs { get; private set; }
        public List<Livre> ListeLivres { get; private set; }

        public Donnees() {
            Auteur jt = new Auteur("Julien", "TRILLARD");
            Auteur tr = new Auteur("Thierry", "RICHARD");
            Auteur cg = new Auteur("Christophe", "GIGAX");
            Auteur ac = new Auteur("Anthony", "COSSON");
            Auteur hb = new Auteur("Hervé", "BOISGONTIER");
            Auteur mm = new Auteur("Mélanie", "Malalaniche");
            ListeAuteurs = new List<Auteur> { jt, tr, cg, ac, hb, mm };
            ListeLivres = new List<Livre> {
                new Livre(1, "Flutter - Développez vos applications mobiles multiplateformes avec Dart", $"Ce livre sur Flutter s'adresse aux développeurs, initiés comme plus aguerris, qui souhaitent disposer des connaissances nécessaires pour créer de A à Z des applications mobiles multiplateformes avec le framework de Google. Tout au long du livre, l'auteur enrichit ses propos à l'aide d'un grand nombre de démonstrations simples à reproduire, permettant au lecteur d'assimiler les connaissances par la pratique.{Environment.NewLine}Après une brève introduction sur le monde du développement mobile et une présentation du framework, un chapitre détaille les étapes d'installation indispensables pour utiliser le framework dans les meilleures conditions. La création d'un premier projet permet d'en étudier plus en détail la structure et le code basé sur le langage Dart. Pour être parfaitement à l'aise sur ce langage, deux chapitres viennent enrichir les connaissances du lecteur avec des notions fondamentales puis plus avancées.{Environment.NewLine}Avec Flutter, tout est widget ! Ainsi, la suite du livre détaille cette notion fondamentale de widget et en présente les principaux. Puis l'auteur étudie la gestion des états qui permettent notamment la mise à jour en temps réel de l'affichage. Les interactions avec l'utilisateur étant indispensables, les pop-ups, la navigation et les formulaires font également l'objet de chapitres dédiés. Un chapitre sur les listes et les grilles permet au lecteur de voir comment optimiser l'affichage de son application.{Environment.NewLine}L'accès aux outils de l'appareil étant primordial pour une application mobile, l'auteur explique comment exploiter les API pour utiliser l'appareil photo et le GPS. Pour finir, il détaille la persistance des données sous différentes formes.", 470, jt),
                new Livre(2, "Java - Les fondamentaux du langage", $"Ce livre, qui couvre jusqu’à la version 17 de Java, s’adresse à tout informaticien désirant développer sous Java. Que le lecteur soit débutant ou qu’il ait déjà une première expérience avec un autre langage, il trouvera dans cet ouvrage toutes les bases nécessaires pour se familiariser rapidement avec un des langages les plus utilisés au monde.{Environment.NewLine}Après une présentation de la plateforme Java SE, de son installation sous Windows et Linux et de l’environnement de développement utilisé dans le cadre de l’ouvrage (Eclipse, MySQL), le lecteur étudie les bases du langage et la programmation orientée objet. Parmi la richesse de l’API Java, un focus est fait sur l’API de gestion des dates, sur les nouvelles possibilités offertes par les interfaces et sur la notion de modules.{Environment.NewLine}Les expressions lambda et les API sous-jacentes comme l’API java.util.function ou l’API Stream sont détaillées avant de passer à l’étude du développement d’applications graphiques avec la bibliothèque Swing. Le développement d’applications client/serveur est également présenté avec l’API JDBC assurant l’accès aux bases de données relationnelles.{Environment.NewLine}Le déploiement étant une étape importante du succès d’une application, le dernier chapitre présente la distribution d’une application avec la solution classique des fichiers d’archives ou l’utilisation des outils jlink et jpackage.{Environment.NewLine}De nombreux exercices avec leurs corrigés permettent au lecteur de valider ses connaissances et de mettre en pratique immédiatement les notions étudiées.", 572, tr),
                new Livre(3, "Java EE - Développez des applications web en Java", $"Ce livre s'adresse aux développeurs souhaitant monter en compétences sur le développement d'applications web, côté serveur, avec les technologies essentielles de la plateforme Java EE 7 (Java Enterprise Edition 7). Des connaissances sur le langage Java sont un prérequis nécessaire à la bonne compréhension du livre.{Environment.NewLine}Tout au long des chapitres, l'auteur aide le lecteur à mettre en place des projets au travers de l'IDE Eclipse lui permettant d'explorer le fonctionnement des technologies décrites.{Environment.NewLine}Le premier chapitre présente Java EE 7, le protocole HTTP et l'environnement de développement utilisé (Java 8, Eclipse Mars, Tomcat 8 et MySQL 5.7). Les deux chapitres suivants présentent en détail les fondamentaux du développement web avec les servlets et les JSP ainsi que les technologies suivantes : les filtres, les événements, les sessions, les cookies, l'EL et les balises JSTL. Le quatrième chapitre traite de la persistance des données, un élément incontournable pour créer une application. La première partie de ce chapitre détaille l'utilisation de l'API JDBC et la seconde partie montre la puissance d'un ORM en présentant la spécification JPA. À l'issue de ces quatre premiers chapitres, le lecteur est capable de créer ses premières applications web en Java.{Environment.NewLine}Pour aller encore plus loin dans la connaissance et la maîtrise des technologies Java liées au développement web, le cinquième chapitre présente la notion de Framework qui permet d'architecturer les applications et d'industrialiser le développement. À ce titre, les bases des Frameworks JSF et Struts 2 sont présentées. L'avant-dernier chapitre est dédié à la mise en œuvre de technologies complémentaires : les Services Web REST et les WebSockets. Enfin, le dernier chapitre s'attarde sur le déploiement d'une application sur Tomcat 8 en traitant des sujets incontournables que sont la sécurité (l'authentification, l'autorisation, HTTPS) et la journalisation.", 659, tr),
                new Livre(4, "ASP.NET Core MVC - Maîtrisez ce framework web puissant, ouvert et multiplateforme", $"Ce livre s'adresse aux développeurs web désireux de maîtriser ASP.NET Core MVC, framework proposé par Microsoft, totalement Open source. L'auteur souhaite fournir au lecteur les bases techniques nécessaires à une utilisation optimale du framework pour construire des applications web riches et modernes. La connaissance de HTML, CSS et C# sont des prérequis indispensables pour tirer le meilleur profit du livre.{Environment.NewLine}Dans un premier temps, l'auteur présente la structure globale d'un projet ASP.NET Core et énumère les nouveaux mécanismes importants intégrés dans le framework, comme la gestion des modèles avec Entity Framework Core ou l'injection de dépendances. Ensuite, chaque chapitre traite d'une problématique particulière telle que l'optimisation (côté serveur et côté client), la globalisation ou encore la gestion des routes et des erreurs qui sont des éléments importants d'une application web. Le développement front-end n'est pas ignoré, avec l'utilisation de certains framework conséquents et modernes comme Bootstrap, Knockout ou encore Angular. L'un des derniers chapitres traite du sujet très important que sont les tests, que les équipes de développement doivent intégrer dès le début dans leur processus d'intégration continue. Le déploiement est le sujet du dernier chapitre et permettra au lecteur de déployer une application web sur Azure, sur IIS et même sur Linux.{Environment.NewLine}Cette nouvelle édition du livre s'enrichit d'un chapitre sur la conteneurisation et l'architecture microservices avec Docker et Kubernetes.{Environment.NewLine}Pour chaque sujet traité, l'auteur présente les outils, les méthodes et les bonnes pratiques du développement avec ASP.NET Core, issus de son expérience dans ce domaine. Des exemples de code illustrent les explications des différentes APIs d'ASP.NET Core, et restent concis pour ne montrer que l'essentiel.", 368, cg),
                new Livre(5, "Kotlin - Les fondamentaux du développement d'applications Android", $"Ce livre sur Kotlin, destiné aux développeurs juniors comme aux développeurs plus expérimentés, a pour objectif de transmettre les bases indispensables de ce langage promu par Google en tant que langage de développement officiel pour Android. Le lecteur y trouvera de quoi devenir autonome dans la création d'une première application mobile Android (en version Oreo 8.0 au moment de l'écriture) avec Kotlin. Pour une bonne compréhension de son contenu, de simples connaissances en programmation orientée objet sont suffisantes.{Environment.NewLine}Les deux premiers chapitres traitent des fondamentaux du langage Kotlin et de la programmation orientée objet. Chaque concept décrit par l'auteur est accompagné d'une explication simple, de la syntaxe ainsi que d’un exemple d’utilisation.{Environment.NewLine}Dans la suite du livre, le lecteur plonge dans le développement d'applications mobiles. L'auteur commence par présenter l'environnement de développement Android Studio avant de détailler les éléments incontournables pour développer une première application (listes, menus, pop-up, fragments…). Il poursuit avec l'étude de la persistance des données et de la programmation concurrente puis présente des composants plus avancés tels que les librairies ANKO et Retrofit ou l'ORM Room…{Environment.NewLine}Chaque concept étudié est associé à une démonstration complète et concrète.", 466, ac),
                new Livre(6, "Algorithmique - Des bases à la programmation orientée objet en Java", $"Tous les langages de programmation ont leurs spécificités mais lorsqu'un développeur crée un nouveau programme, la première étape est toujours la même : réfléchir à l'enchaînement des différentes actions à réaliser par la machine. L'objectif de ce livre est de vous apprendre à comprendre et concevoir les algorithmes permettant le fonctionnement d'un programme.{Environment.NewLine}Pour cela, après une introduction générale sur l'algorithmique, vous apprenez les bases de la programmation en utilisant du pseudo-code : variables, conditionnelles, boucles, tableaux, procédures et fonctions.{Environment.NewLine}Ensuite, ce livre présente les concepts de la programmation orientée objet, utilisée par la plupart des langages actuels, en utilisant l'algorithmique mais également comment programmer en orienté objet avec Java. Ainsi, vous apprenez à créer des classes et des instances de celles-ci, à créer des associations entre elles, à utiliser la notion d'héritage, de classes abstraites et d'interfaces. Vous serez capable de traiter des exceptions et de traquer les bugs de vos applications.{Environment.NewLine}Enfin, le dernier chapitre du livre est consacré à l'organisation de la mémoire afin de mieux comprendre le fonctionnement de la programmation.{Environment.NewLine}Afin de vous aider à mettre en pratique et à développer votre maîtrise de l'algorithmique et de Java, des exercices sont proposés avec leurs corrections en pseudo-code ainsi que leurs implémentations en Java.{Environment.NewLine}La plupart des algorithmes de ce livre sont implémentés en Java et les sources, directement utilisables, sont disponibles en téléchargement sur le site www.editions-eni.fr.", 400, hb),
                new Livre(7, "Green IT et accessibilité - Développez votre site web Numérique Responsable", $"L'écoconception et l'accessibilité des sites web sont des défis majeurs que les entreprises doivent désormais relever. Ce livre à l'approche très pragmatique et concrète est fait pour former et transmettre aux développeurs et développeuses web les bonnes pratiques en matière d'écoconception et d'accessibilité numérique.{Environment.NewLine}Le livre s'ouvre sur un premier chapitre introduisant les différentes facettes du Numérique Responsable afin de bien comprendre les enjeux et l'importance de développer des sites à la fois de manière plus écologique et conçus pour être accessibles à tous. L'auteur indique ensuite comment auditer un site internet à la fois pour faire un état des lieux, mais également pour l'améliorer et attester de son niveau de green IT et d'accessibilité.{Environment.NewLine}Le chapitre sur la conception du site est central puisque de cette étape dépend en grande partie la réussite du site aussi bien d'un point de vue green IT qu'accessibilité. Les chapitres qui suivent détaillent pour chaque élément de contenu des sites (textes, navigation, images, médias audio et vidéo, tableaux, cartes, documents à télécharger, formulaires…) les bonnes pratiques à utiliser et surtout comment les mettre en œuvre.{Environment.NewLine}Deux chapitres sont axés sur le green IT pour montrer comment effectuer des traitements les plus efficaces et économes possibles sur le navigateur et sur le serveur web ainsi que sur le serveur de bases de données.{Environment.NewLine}Enfin, le dernier chapitre traite de l'hébergement et du paramétrage du serveur web.{Environment.NewLine}En complément de ce livre, un site web (https://numeriqueresponsable.zici.fr) a été créé permettant d'apporter des compléments et de mettre à jour des informations au fur et à mesure des évolutions du web. Ce site sert d'exemple tout au long du livre pour illustrer les propos des différents chapitres.", 323, hb),
            };
            jt.AjouterFacture(new Facture(3200, jt));
            tr.AjouterFacture(new Facture(2800, tr));
            tr.AjouterFacture(new Facture(3200, tr));
            cg.AjouterFacture(new Facture(2300, cg));
            ac.AjouterFacture(new Facture(3400, ac));
            hb.AjouterFacture(new Facture(2800, hb));
            hb.AjouterFacture(new Facture(3200, hb));
        }

        public void Requetes() {
            // 1 - Afficher les livres écrits par Thierry RICHARD
            Console.WriteLine("1- Afficher les livres écrits par Thierry RICHARD");
            // Utilisation de LINQ pour filtrer les livres écrits par Thierry Richard
            var livresThierryRichard = ListeLivres.Where(livre => livre.Auteur.Nom == "RICHARD" && livre.Auteur.Prenom == "Thierry");

            // Affichage des livres écrits par Thierry Richard
            foreach (var livre in livresThierryRichard)
            {
                Console.WriteLine($"Titre : {livre.Titre}, Auteur : {livre.Auteur.Nom} {livre.Auteur.Prenom}");
            }
            // 2 - Afficher la liste des noms des auteurs dont le prénom se termine par "y"

            var auteursPrenomY = ListeAuteurs
            .Select(auteur => auteur.Prenom) // Récupère le prénom de l'auteur
            .Where(prenom => prenom.EndsWith("y")); // Filtrer les prénoms se terminant par "y"
            Console.WriteLine("2- Liste des auteurs dont le prénom se termine par y");
            foreach (var auteur in auteursPrenomY)
            {
                Console.WriteLine(auteur);
            }
            // 3 - Afficher les titres de tous les livres triés par ordre alphabétique

            Console.WriteLine("3- Afficher les titres de tout les livres triés par ordre alphabétique:");
            var titresTries = ListeLivres
            .Select(livre => livre.Titre) // Sélectionne uniquement les titres
            .OrderBy(titre => titre); // Trie les titres par ordre alphabétique

            foreach (var titre in titresTries)
            {
                Console.WriteLine(titre);
            }

            // 4 - Les auteurs ayant écrit des livres de plus de 400 pages

            Console.WriteLine("4- Les auteurs ayant écrit des livres de plus de 400 pages");
            var auteursPlus400Pages = ListeLivres
            .Where(livre => livre.NbPages > 400) // Filtrer les livres de plus de 400 pages
            .Select(livre => livre.Auteur) // Sélectionne les auteurs correspondants
            // Si tu veux afficher les auteurs sans répétition
            .Distinct();

            foreach (var auteur in auteursPlus400Pages)
            {
                Console.WriteLine(auteur.Prenom +" "+ auteur.Nom);
            }

            // 5 - Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne

            // 6 - Le livre ayant le titre le plus long

            // 7 - Afficher le titre du livre avec le plus de pages

            // 8 - Afficher les auteurs et la liste de leurs livres

            // 9 - Afficher le nombre moyen de pages des livres par auteur

            // 10 - Afficher l’auteur ayant écrit le plus de livres

            // 11 - Afficher le montant moyen d'une facture

            // 12 - Afficher l'auteur ayant écrit le moins de livres

        }
    }
}

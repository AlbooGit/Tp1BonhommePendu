/*
 * A COMPLÉTER
 *
 *
 * Collaboration avec: Mike Vezina, Jade Loupret et Samuel Cloutier gr.0002
 * Auteur: Albert Ouellet gr.0002
 * */
using System;
using System.Text;
using System.Media;

namespace ProgrammationJeuxVideo1
{
    public class TP1Etu 
    {
        private static object Properties;
        #region Constantes de programme
        // A COMPLETER
        #endregion

        /// <summary>
        /// La méthode Run est le point de départ (point d'entrée)
        /// dans notre application.
        /// </summary>
        public void Run()
        {
            // Préciser les dimensions de la fenêtre de jeu. Une seule fois, au début du programme.
            Console.SetWindowSize(90, 33);
            Console.BufferWidth = 90;
            Console.BufferHeight = 33;
            Console.BackgroundColor = ConsoleColor.Black;           //Ces lignes servent de paramètres de départ pour la console.
            Console.ForegroundColor = ConsoleColor.Magenta;
            JouerMusiqueDeFond(); //Démarre la musique

            // Boucle principale du jeu
            bool joueurVeutJouer = true; 

            while (joueurVeutJouer)     //Lorsque joueurVeutJouer est false l'application se ferme.
            // ==> Compléter ici en codant la répétitive appropriée
            {
                // Affichage de l'écran principal
                // A COMPLÉTER
                AffichageEcranPrincipal(); 

                // Demander au joueur ce qu'il souhaite faire: jouer ou quitter
                // A COMPLÉTER

                joueurVeutJouer = DemanderSiJoueurVeutQuitter(); //Vérifier si le joueur veut jouer pour changer le bool s'il ne veut pas.


                // Démarrer une partie si le joueur ne veut pas quitter
                // A COMPLÉTER

               if (joueurVeutJouer == true)
                {
                    JouerUnePartie();
                }
               

            }

        }


        #region Gestion d'une partie



        void JouerUnePartie()
        {
            // Faites les appels requis pour afficher l'entête et le pied de page du jeu.
            // A COMPLÉTER

            
            AfficherEnteteJeu();  //Faire l'affichage de l'écran de jeu.
            AfficherPiedDePage(); //Faire l'affichage de l'écran de jeu.


            // Déclarez ici les variables qui vous serviront à compter le nombre de mots ratés et réussis.
            // A COMPLÉTER
            int nombreMotsRates = 0; 
            int nombreMotsTrouves = 0;

            // Utilisez ici la répétitive appropriée pour boucler tant que la partie n'est pas terminée.
            while (nombreMotsRates < 3) //Une boucle, si jamais le joueur manque 3 mots, la partie se termine.
            {
                // Faites l'appel requis pour afficher les statistiques de la partie
                // A COMPLÉTER
                AfficherStatistiquesPartie(nombreMotsTrouves,nombreMotsRates);

                // Jouer un mot...
                // A COMPLÉTER
                bool motCourantTrouve = JouerUnMot(); //Détermine quel mot sera joué


                // Complétez ce qui doit être fait après qu'un mot ait été joué.
                // A COMPLÉTER        
                if (motCourantTrouve == true) //Le mot a été trouvé alors on incrémente le compteur de mots réussi puis on joue de la musique.
                {
                    nombreMotsTrouves++;
                    MusiqueMotReussi();                 
                }
                else //Le mot n'est pas trouvé avec les 4 essaies, on incrémente le compteur de mots raté puis on joue la musique de mot raté.
                {
                    nombreMotsRates++;
                    MusiqueMotRate();
                }

                
            }
            Console.Clear(); //Nettoyer l'écran de jeu pour afficher le Console.Writeline.
            Console.WriteLine(@"   







                _____          __  __ ______    ______      ________ _____  
               / ____|   /\   |  \/  |  ____|  / __ \ \    / /  ____|  __ \ 
              | |  __   /  \  | \  / | |__    | |  | \ \  / /| |__  | |__) |
              | | |_ | / /\ \ | |\/| |  __|   | |  | |\ \/ / |  __| |  _  / 
              | |__| |/ ____ \| |  | | |____  | |__| | \  /  | |____| | \ \ 
               \_____/_/    \_\_|  |_|______|  \____/   \/   |______|_|  \_\
                                                               
                    __     ______  _    _   _      ____   _____ ______ 
                    \ \   / / __ \| |  | | | |    / __ \ / ____|  ____|
                     \ \_/ / |  | | |  | | | |   | |  | | (___ | |__   
                      \   /| |  | | |  | | | |   | |  | |\___ \|  __|  
                       | | | |__| | |__| | | |___| |__| |____) | |____ 
                       |_|  \____/ \____/  |______\____/|_____/|______| 


                                   (Press Any Button) ");
            

            DemanderSiJoueurVeutQuitter(); //Vérifier si le joueur veut faire une autre partie
        }

        // Écrire ici l'entête (la 1re ligne) de la méthode JouerUnMot
        /// <summary>
        /// Choisi le mot pour le mettre en jeu, le masque, mets sa position dans la console, vérifie les lettres entrées par l'utilisateur si elles correspondent 
        /// correspondent entrées par l'utilisateur si elles correspondent à celles du mot en jeu. Change la ligne si la lettre était mauvaise.
        /// </summary>
        /// <returns> booléen, si le mot est en jeu sera vrai. </returns>
        bool JouerUnMot() //Choisi le mot pour le mettre en jeu, le masque, mets sa position dans la console, vérifie les lettres entrées par l'utilisateur si elles correspondent 
                          // à celles du mot en jeu. Change la ligne si la lettre était mauvaise.
        {
        // Choisir un mot à trouver parmi une liste de mots prédéterminés.
        // Faites l'appel à ChoisirMotAleatoire et placez le résultat dans la variable appropriée
            string motATrouver = ChoisirMotAleatoire();
            // Encrypter le mot en question
            // A COMPLÉTER
            string motMasque = MasquerMot(motATrouver);

            // Déterminer la position de départ du mot pour son affichage.  
            // A COMPLÉTER
            int positionDuMotY = 12;
            int positionDuMotX = 40;
            Console.SetCursorPosition(positionDuMotX, positionDuMotY);
            // Écrivez ici la répétitive nécessaire pour jouer un mot .
            // Vous devrez probablement faire l'appel de la méthode DeterminerEtatMotCourant et utiliser son
            // résultat dans votre condition.
            int nbCaracteresManques = 0;
            while (DeterminerEtatMotCourant(motATrouver, motMasque, nbCaracteresManques) == 0)
            {
                Console.SetCursorPosition(positionDuMotX, positionDuMotY);
                Console.WriteLine(motMasque);
                // Faites l'appel de la méthode SaisirLettreEntreAetZ ici 
                // A COMPLÉTER
                char lettreSaisie = SaisirLettreEntreAetZ();
                
                // Étape 4.4 ici
                // A COMPLÉTER
                if (motATrouver.Contains(lettreSaisie.ToString())) //if qui vérifie si la lettre est dans le motATrouver
                {
                    for (int i = 0; i < motATrouver.Length; i++) //For, parcours chaque lettre du mots. Si la lettreSaisie = la lettre parcouru, elle change l'astérisque pour la lettre saisie

                    {
                        if (motATrouver[i] == lettreSaisie)
                        {
                            StringBuilder motAModifier = new StringBuilder(motMasque);
                            motAModifier[i] = lettreSaisie;
                            motMasque = motAModifier.ToString();
                        }
                    }
                }
                else
                {
                    nbCaracteresManques++;
                    positionDuMotY++;
                }


                // Étape 4.5 ICI
                // A COMPLÉTER
                AfficherMotMasque(motMasque, positionDuMotX, positionDuMotY); //Affiche le mot censuré
                

            }

            if (DeterminerEtatMotCourant(motATrouver, motMasque, nbCaracteresManques) == -1) //Retourne le booléen à la méthode dépendamment de l'int reçu par déterminermotcourant.
            {
                return false;
            }
            
            return true; 
        }


        /// <summary>
        /// Choisit un mot de manière aléatoire parmi une liste de mots possibles.
        /// </summary>
        /// <returns>Le mot choisi de manière aléatoire</returns>
        string ChoisirMotAleatoire()
        {
            // Vous pouvez ajouter d'autres mots en ajoutant des chaînes après "allo":
            // string[] listeDeMotsPossibles = new string[] { "allo", "mot2", "mot3", "etc" };
            string[] listeDeMotsPossibles = new string[] { "kirby", "king dedede", "meta knight", "wheelie", "tac", "rocky",
            "chilly", "bonkers", "blade knight", "bio spark", "birdon", "bugzzy", "burning leo", "capsule j/2", "knuckle joe",
            "plasma wisp", "simirror", "waddle doo", "sword knight", "gim", "poppy bro jr."};

            Random rnd = new Random();
            return listeDeMotsPossibles[rnd.Next(0, listeDeMotsPossibles.Length)].ToLower();
        }
        #endregion

        

        #region Methodes
        /// <summary>
        /// fait afficher un console.writeline qui est créé pour être le bas de la page.
        /// </summary>
        void AfficherPiedDePage()
        {
            Console.SetCursorPosition(0, 22);
            Console.WriteLine(@"
  ========================================================================================
                               Projet par: Albert Ouellet
                                        Gr. 0002
                  Pour le cours: 420-V12-SF PROGRAMMATION DE JEUX VIDÉO I 

");

        }

        /// <summary>
        /// Fait afficher un console.writeline qui est un écran principal.
        /// </summary>
        void AffichageEcranPrincipal()
        {

            Console.WriteLine(@" 
               ______    _ _ _              __          __           _     
              |  ____|  | | (_)             \ \        / /          | |    
              | |__ __ _| | |_ _ __   __ _   \ \  /\  / /__  _ __ __| |___ 
              |  __/ _` | | | | '_ \ / _` |   \ \/  \/ / _ \| '__/ _` / __|
              | | | (_| | | | | | | | (_| |    \  /\  / (_) | | | (_| \__ \
              |_|  \__,_|_|_|_|_| |_|\__, |     \/  \/ \___/|_|  \__,_|___/
                                      __/ |                                
                                     |___/                                 
                                   
                                Kirby Edition ( -‘ _ ‘- )
                                  Only Lowercase words!");


            Console.WriteLine(@"


                        Voulez vous jouer? Oui: [O] Non: [N]");

            AfficherPiedDePage();

        }
        /// <summary>
        /// Demande au joueur si il veut quitter le jeu
        /// </summary>
        /// <returns> retourne booléen, ce qui décide oui/non il veut jouer</returns>
        bool DemanderSiJoueurVeutQuitter()
        {
            char choix = Console.ReadKey().KeyChar;
            bool choixJoueur;
            if (choix == 'n')
            {
                choixJoueur = false;
                Console.Clear(); //Efface l'écran avant que le programme se ferme.
            }
            else
            {
                choixJoueur = true;
                Console.Clear(); //Effacer l'écran pour préparer à l'affichage de l'écran de jeu.
            }

            return choixJoueur;

        }
        /// <summary>
        /// Fait afficher un console.writeline qui est un entêtre de jeu, le haut de la page.
        /// </summary>
        void AfficherEnteteJeu()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(@"
               ==========================================================
               ______    _ _ _               _    _               _     
               |  ___|  | | (_)             | |  | |             | |    
               | |_ __ _| | |_ _ __   __ _  | |  | | ___  _ __ __| |___ 
               |  _/ _` | | | | '_ \ / _` | | |/\| |/ _ \| '__/ _` / __|
               | || (_| | | | | | | | (_| | \  /\  / (_) | | | (_| \__ \
               \_| \__,_|_|_|_|_| |_|\__, |  \/  \/ \___/|_|  \__,_|___/
                                      __/ |                             
                                     |___/                          
               ==========================================================");
        }
        /// <summary>
        /// Permet d'afficher le nombre de mots trouvés et manqués avec un console.writeline.
        /// </summary>
        /// <param name="nombreMotsTrouves"></param>
        /// <param name="nombreMotsRates"></param>
        void AfficherStatistiquesPartie(int nombreMotsTrouves, int nombreMotsRates)
        {
            Console.WriteLine("Vous avez {0} mots trouvés et {1} mots manqués.", nombreMotsTrouves, nombreMotsRates);
        }
        /// <summary>
        /// La fonction permet de censurer le mot en remplaçant les lettres par des astérisques.
        /// </summary>
        /// <param name="motAMasquer"></param>
        /// <returns></returns>
        string MasquerMot(string motAMasquer)
        {
            string motMasque = "";
            for (int i = 0; i < motAMasquer.Length; i++)
            {
                motMasque += '*';
            }
            return motMasque;
        }
        /// <summary>
        /// Détermine si le jouer à trop râté de lettres. Si oui il envoit un int. Ce int est utilisé pour déterminer si la partie est en marche ou pas.
        /// </summary>
        /// <param name="motATrouver"></param>
        /// <param name="MotMasque"></param>
        /// <param name="nbCaracteresManques"></param>
        /// <returns></returns>
        int DeterminerEtatMotCourant(string motATrouver,string MotMasque,int nbCaracteresManques)
        {
            if (nbCaracteresManques >= 4)
            {
                return -1;
            }
               
            else if (motATrouver == MotMasque)
            {
                return 1;
            }
            else
            {
                nbCaracteresManques++;
                return 0;
            }
        }
        /// <summary>
        /// Cette fonction enregistre la lettre sélectionné par l'utilisateur. 
        /// </summary>
        /// <returns> un char, la lettre sélectionné par l'utilisateur. </returns>
        char SaisirLettreEntreAetZ()
        {
            var lettreSaisie = Console.ReadKey();
            return lettreSaisie.KeyChar;
        }
        /// <summary>
        /// Cette fonction permet d'afficher le mot censuré à un certain endroit selon les positions X et Y. 
        /// </summary>
        /// <param name="motMasque"></param>
        /// <param name="positionDuMotX"></param>
        /// <param name="positionDuMotY"></param>
        void AfficherMotMasque(string motMasque, int positionDuMotX, int positionDuMotY)
        {
            Console.Clear(); //Efface l'écran pour permettre au mot de se déplacer d'une ligne.
            AfficherEnteteJeu();
            if (positionDuMotY != 16)
            {
                Console.SetCursorPosition(positionDuMotX, positionDuMotY);
                Console.WriteLine(motMasque);
            }
            AfficherPiedDePage();
        }
        /// <summary>
        /// Cette fonction permet de jouer de la musique de fond.
        /// </summary>
        void JouerMusiqueDeFond()
        {
            SoundPlayer GourmetRace = new SoundPlayer(@"..\..\Resources\GourmetRace.wav");
            GourmetRace.PlayLooping(); 
        }
        /// <summary>
        /// Cette fonction fait jouer un son lorsque la fonction est appelée.
        /// </summary>
        void MusiqueMotRate()
        {
            System.Media.SoundPlayer KirbyDeath = new System.Media.SoundPlayer(@"..\..\Resources\KirbyDeath.wav");
            KirbyDeath.Play();
        }
        /// <summary>
        /// Cette fonction fait jouer un son lorsque la fonction est appelée.
        /// </summary>
        void MusiqueMotReussi()
        {
            System.Media.SoundPlayer KirbyHi = new System.Media.SoundPlayer(@"..\..\Resources\KirbyHi.wav");
            KirbyHi.PlaySync();
        }
        #endregion

    }
}

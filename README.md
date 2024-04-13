# FoulFlex

## Prérequis

Avant de démarrer le projet, vous devez installer les outils suivants et configurer votre environnement de développement :

- [Unity](https://unity.com/) : Un moteur de jeu puissant utilisé pour développer et construire le projet. Avant d'installer Unity, vous devez créer un compte Unity sur leur site web. Après avoir créé votre compte, vous devrez activer une licence. La licence personnelle gratuite peut suffire. Suivez les instructions sur le site de Unity pour activer votre licence après l'installation.
- [Git](https://git-scm.com/) : Nécessaire pour le clonage du repository. Assurez-vous de télécharger et d'installer la dernière version compatible avec votre système d'exploitation.

## Clonage du projet

Pour obtenir une copie du projet sur votre machine locale, procédez comme suit :

1. Ouvrez un terminal.
2. Naviguez vers le répertoire où vous souhaitez cloner le projet.
3. Exécutez la commande suivante :

```git
git clone https://github.com/TLBail/FoulFlex/
```

## Lancement du projet
Pour ouvrir et démarrer le projet dans Unity, suivez ces étapes :

- Lancez Unity Hub et cliquez sur "Ajouter".
- Naviguez vers le dossier du projet cloné et sélectionnez-le.
- Cliquez sur "Ouvrir" pour charger le projet dans Unity.
- Vous êtes maintenant prêt à travailler sur le projet dans Unity.


## Construction du projet Unity
Pour construire une version exécutable de votre projet Unity, suivez les instructions ci-dessous :

Dans Unity, accédez à Fichier > Build Settings.
Assurez-vous que la plateforme cible est correctement définie (par exemple, "PC, Mac & Linux Standalone" pour un build Windows).
Cliquez sur Build.
Choisissez le répertoire de destination pour le build et confirmez par Enregistrer.
Vous avez maintenant construit une version de votre projet Unity prête à être exécutée.


## Communication entre Unity et TouchDesigner via OSC

Le projet Unity est configuré pour envoyer des données en utilisant le protocole OSC (Open Sound Control) à `localhost` sur le port `7000`. Cette configuration permet une communication directe avec TouchDesigner. Les messages OSC spécifiques envoyés par Unity incluent :

- **Événement de nettoyage** : Envoyé à l'adresse OSC `/cleaning`. Ce message est utilisé pour signaler à TouchDesigner qu'une opération de nettoyage a eu lieu dans le jeu.(valeur 1)
- **Nouvelle valeur du fouling** : Envoyé à l'adresse OSC `/fouling`. Ce message informe TouchDesigner de la mise à jour de la valeur de fouling (encrassement) dans le jeu. (flotant entre 0 et 1)


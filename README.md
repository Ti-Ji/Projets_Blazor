# Projet Fil Rouge : Gestionnaire de Mots de Passe

## Description
Ce projet vise à développer une solution Blazor pour un gestionnaire de mots de passe, destiné aux étudiants en enseignement supérieur. Il permettra aux utilisateurs de stocker, gérer et accéder à leurs mots de passe en toute sécurité grâce à une interface conviviale.

## Fonctionnalités principales
- **Authentification** : Inscription, connexion.
- **Gestion des mots de passe** : Ajouter, modifier et supprimer des mots de passe.
- **Catégorisation** : Organiser les mots de passe par catégorie.
- **Recherche rapide** : Trouver facilement des mots de passe via une barre de recherche.
- **Chiffrement** : Sécuriser les données avec des algorithmes de chiffrement robustes.
- **Mode hors ligne** : Accès local sécurisé sans dépendance réseau.
- **Sécurité** : Utilisation d’un mot de passe principal pour la décryptage, verrouillage après tentatives échouées.
- **Générateur de mots de passe** : Génération de mots de passe complexes et sécurisés avec critères personnalisables.
- **Sauvegarde** : sur une base de données SQLite.
- **Interface utilisateur** : Simple, intuitive, et responsive avec recherche et filtrage des mots de passe.
- **Points bonus**: Tests unitaires, et Application mobile

## Technologies utilisées
- **Framework front-end** : [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
- **Backend** : ASP.NET Core Web API
- **Base de données** : SQLite ou une alternative locale légère
- **Autres** : Entity Framework Core, Dependency Injection, etc.

## Prérequis
1. **Outils et environnement** :
   - [JetBrains Rider](https://www.jetbrains.com/rider/), [Visual Studio](https://visualstudio.microsoft.com/) 2022 ou une version ultérieure avec le workload `.NET`, ou [Visual Studio Code](https://code.visualstudio.com/).
   - [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0).
   - Git pour la gestion des versions.


## Structure du projet
```
.
├── src
│   ├── PasswordManager.Web      # Projet Blazor (Frontend)
│   ├── PasswordManager.Api      # API Backend
│   └── PasswordManager.Core     # Logique métier
├── tests
│   └── PasswordManager.Tests    # Tests unitaires et d'intégration
└── README.md                    # Documentation avec votre **Prénom et NOM**, ainsi que les fonctionnalités réalisées
```

## Rendu du projet
- dépôt sur github (personnel) et m'envoyer le lien par mail: [theojulien.pro@outlook.com](mailto:theojulien.pro@outlook.com?subject=[GitHub]%20Rendu%20Projet%20Blazor)
- 28 Février 2025 à 23H59.

## Liens utiles
- [Documentation Blazor](https://docs.microsoft.com/fr-fr/aspnet/core/blazor/)
- [Entity Framework Core](https://docs.microsoft.com/fr-fr/ef/core/)
- [SQLite](https://www.sqlite.org/docs.html)

--- 

## Auteurs
- **[Votre Nom]** - Étudiant(e) ou développeur(se) principal(e)

## Licence
Ce projet est sous licence MIT - voir le fichier [LICENSE](LICENSE) pour plus de détails.

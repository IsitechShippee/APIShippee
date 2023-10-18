INSERT INTO `annoucement_status` (`id`, `status`) VALUES
(1, 'Privée'),
(2, 'Disponible'),
(3, 'Supprimée');

INSERT INTO `chat_status` (`id`, `status`) VALUES
(1, 'Envoyer'),
(2, 'Lu');


INSERT INTO `companies` (`siren`, `name`, `id_naf`, `picture`, `street`, `cp`, `city`, `legal_form`, `id_effective`, `web_site`, `payment`) VALUES
(123456788, 'InnovaTech', 20, '', '15 Rue de la Science', '75013', 'Paris', 'SAS', 2, 'https://www.innovatech.com', 0),
(151413120, 'EuroDesign', 20, '', '5 Rue de l\'Europe', '13001', 'Marseille', 'SARL', 1, 'https://www.eurodesign.com', 1),
(171615140, 'TechConnect', 1, '', '22 Rue de la Technologie', '69008', 'Lyon', 'SA', 1, 'https://www.techconnect.com', 0),
(201918170, 'AlphaBeta', 20, '', '11 Rue de l\'Alphabet', '75009', 'Paris', 'SARL', 2, 'https://www.alphabeta.com', 0),
(246810120, 'Alpina', 2, '', '7 Rue de la Montagne', '74000', 'Annecy', 'SA', 2, 'https://www.alpina.com', 1),
(369121517, 'Solutions et Co', 20, '', '18 Rue des Solutions', '69002', 'Lyon', 'SAS', 3, 'https://www.solutionsco.com', 1),
(987654320, 'Société Nouvelle', 2, '', '32 Rue de l\'Industrie', '69009', 'Lyon', 'SARL', 1, 'https://www.societe-nouvelle.com', 0);

INSERT INTO `diplomes` (`id`, `diplome`) VALUES
(1, 'sans diplôme'),
(2, 'bac'),
(3, 'bac+2'),
(4, 'bac+3'),
(5, 'bac+5');

INSERT INTO `effectives` (`id`, `type`) VALUES
(1, '1 à 10'),
(2, '11 à 50'),
(3, '51 et plus');

INSERT INTO `naf_sections` (`id`, `title`) VALUES
(1, 'Agriculture, sylviculture et pêche'),
(2, 'Industries extractives'),
(3, 'Industrie manufacturière'),
(4, 'Production et distribution d\'électricité, de gaz, de vapeur et d\'air conditionné'),
(5, 'Production et distribution d\'eau ; assainissement, gestion des déchets et dépollution'),
(6, 'Construction'),
(7, 'Commerce ; réparation d\'automobiles et de motocycles'),
(8, 'Transports et entreposage'),
(9, 'Hébergement et restauration'),
(10, 'Information et communication'),
(11, 'Activités financières et d\'assurance'),
(12, 'Activités immobilières'),
(13, 'Activités spécialisées, scientifiques et techniques'),
(14, 'Activités de services administratifs et de soutien'),
(15, 'Administration publique'),
(16, 'Enseignement'),
(17, 'Santé humaine et action sociale'),
(18, 'Arts, spectacles et activités récréatives'),
(19, 'Autres activités de services'),
(20, 'Activités des ménages en tant qu\'employeurs ; activités indifférenciées des ménages en tant que producteurs de biens et services pour usage propre'),
(21, 'Activités extra-territoriales');

INSERT INTO `naf_divisions` (`id`, `id_naf_section`, `title`) VALUES
(1, 1, 'Culture et production animale, chasse et services annexes'),
(2, 1, 'Sylviculture et exploitation forestière'),
(3, 1, 'Pêche et aquaculture'),
(4, 2, 'Extraction de houille et de lignite'),
(5, 2, 'Extraction d\'hydrocarbures'),
(6, 2, 'Extraction de minerais métalliques'),
(7, 2, 'Autres industries extractives'),
(8, 2, 'Services de soutien aux industries extractives'),
(9, 3, 'Industries alimentaires'),
(10, 3, 'Fabrication de boissons'),
(11, 3, 'Fabrication de produits à base de tabac'),
(12, 3, 'Fabrication de textiles'),
(13, 3, 'Industrie de l\'habillement'),
(14, 3, 'Industrie du cuir et de la chaussure'),
(15, 3, 'Travail du bois et fabrication d\'articles en bois et en liège, à l\'exception des meubles ; fabrication d\'articles en vannerie et sparterie'),
(16, 3, 'Industrie du papier et du carton'),
(17, 3, 'Imprimerie et reproduction d\'enregistrements'),
(18, 3, 'Cokéfaction et raffinage'),
(19, 3, 'Industrie chimique'),
(20, 3, 'Industrie pharmaceutique'),
(21, 3, 'Fabrication de produits en caoutchouc et en plastique'),
(22, 3, 'Fabrication d\'autres produits minéraux non métalliques'),
(23, 3, 'Métallurgie'),
(24, 3, 'Fabrication de produits métalliques, à l\'exception des machines et des équipements'),
(25, 3, 'Fabrication de produits informatiques, électroniques et optiques'),
(26, 3, 'Fabrication d\'équipements électriques'),
(27, 3, 'Fabrication de machines et équipements n.c.a.'),
(28, 3, 'Industrie automobile'),
(29, 3, 'Fabrication d\'autres matériels de transport'),
(30, 3, 'Fabrication de meubles'),
(31, 3, 'Autres industries manufacturières'),
(32, 3, 'Réparation et installation de machines et d\'équipements'),
(33, 4, 'Production et distribution d\'électricité, de gaz, de vapeur et d\'air conditionné'),
(34, 5, 'Captage, traitement et distribution d\'eau'),
(35, 5, 'Collecte et traitement des eaux usées'),
(36, 5, 'Collecte, traitement et élimination des déchets ; récupération'),
(37, 5, 'Dépollution et autres services de gestion des déchets'),
(38, 6, 'Construction de bâtiments'),
(39, 6, 'Génie civil'),
(40, 6, 'Travaux de construction spécialisés'),
(41, 7, 'Commerce et réparation d\'automobiles et de motocycles'),
(42, 7, 'Commerce de gros, à l\'exception des automobiles et des motocycles'),
(43, 7, 'Commerce de détail, à l\'exception des automobiles et des motocycles'),
(44, 8, 'Transports terrestres et transport par conduites'),
(45, 8, 'Transports par eau'),
(46, 8, 'Transports aériens'),
(47, 8, 'Entreposage et services auxiliaires des transports'),
(48, 8, 'Activités de poste et de courrier'),
(49, 9, 'Hébergement'),
(50, 9, 'Restauration'),
(51, 10, 'Édition'),
(52, 10, 'Production de films cinématographiques, de vidéo et de programmes de télévision ; enregistrement sonore et édition musicale'),
(53, 10, 'Programmation et diffusion'),
(54, 10, 'Télécommunications'),
(55, 10, 'Programmation, conseil et autres activités informatiques'),
(56, 10, 'Services d\'information'),
(57, 11, 'Activités des services financiers, hors assurance et caisses de retraite'),
(58, 11, 'Assurance'),
(59, 11, 'Activités auxiliaires de services financiers et d\'assurance'),
(60, 12, 'Activités immobilières'),
(61, 13, 'Activités juridiques et comptables'),
(62, 13, 'Activités des sièges sociaux ; conseil de gestion'),
(63, 13, 'Activités d\'architecture et d\'ingénierie ; activités de contrôle et analyses techniques'),
(64, 13, 'Recherche-développement scientifique'),
(65, 13, 'Publicité et études de marché'),
(66, 13, 'Autres activités spécialisées, scientifiques et techniques'),
(67, 13, 'Activités vétérinaires'),
(68, 14, 'Activités de location et location-bail'),
(69, 14, 'Activités liées à l\'emploi'),
(70, 14, 'Activités des agences de voyage, voyagistes, services de réservation et activités connexes'),
(71, 14, 'Enquêtes et sécurité'),
(72, 14, 'Services relatifs aux bâtiments et aménagement paysager'),
(73, 14, 'Activités administratives et autres activités de soutien aux entreprises'),
(74, 15, 'Administration publique et défense ; sécurité sociale obligatoire'),
(75, 16, 'Enseignement'),
(76, 17, 'Activités pour la santé humaine'),
(77, 17, 'Hébergement médico-social et social'),
(78, 17, 'Action sociale sans hébergement'),
(79, 18, 'Activités créatives, artistiques et de spectacle'),
(80, 18, 'Bibliothèques, archives, musées et autres activités culturelles'),
(81, 18, 'Organisation de jeux de hasard et d\'argent'),
(82, 18, 'Activités sportives, récréatives et de loisirs'),
(83, 19, 'Activités des organisations associatives'),
(84, 19, 'Réparation d\'ordinateurs et de biens personnels et domestiques'),
(85, 19, 'Autres services personnels'),
(86, 20, 'Activités des ménages en tant qu\'employeurs de personnel domestique'),
(87, 20, 'Activités indifférenciées des ménages en tant que producteurs de biens et services pour usage propre'),
(88, 21, 'Activités des organisations et organismes extraterritoriaux');

INSERT INTO `skills` (`id`, `title`) VALUES
(1, 'Programmation informatique'),
(2, 'Conception graphique'),
(3, 'Développement de logiciels'),
(4, 'Analyse de données'),
(5, 'Ingénierie'),
(6, 'Comptabilité'),
(7, 'Gestion de projets'),
(8, 'Marketing numérique'),
(9, 'Développement Web'),
(10, 'Langues étrangères'),
(11, 'Statistiques'),
(12, 'Gestion des bases de données'),
(13, 'Sciences de la santé'),
(14, 'Gestion des réseaux informatiques'),
(15, 'Électricité et électronique'),
(16, 'Maintenance et réparation de machines'),
(17, 'Droit'),
(18, 'Rédaction technique'),
(19, 'Architecture et design d\'intérieur'),
(20, 'Conception de produits'),
(21, 'Analyse de marché'),
(22, 'Recherche scientifique'),
(23, 'Gestion des finances'),
(24, 'Modélisation 3D'),
(25, 'Programmation de robots'),
(26, 'Intelligence artificielle et apprentissage automatique'),
(27, 'Évaluation de la performance'),
(28, 'Conception de circuits électroniques'),
(29, 'Développement de jeux vidéo'),
(30, 'Conception d\'interfaces utilisateur (UI/UX)'),
(31, 'Évaluation de la qualité'),
(32, 'Conception de systèmes embarqués'),
(33, 'Sécurité informatique'),
(34, 'Fabrication industrielle'),
(35, 'Programmation de bases de données'),
(36, 'Analyse de risques'),
(37, 'Développement de logiciels embarqués'),
(38, 'Conception de circuits intégrés'),
(39, 'Traitement de l\'image et vision par ordinateur'),
(40, 'Modélisation et simulation'),
(41, 'Conception de systèmes électroniques'),
(42, 'Contrôle de processus industriels'),
(43, 'Conception assistée par ordinateur (CAO)'),
(44, 'Conception de systèmes d\'information géographique (SIG)'),
(45, 'Optimisation de la chaîne d\'approvisionnement'),
(46, 'Planification de production'),
(47, 'Analyse de performances de systèmes'),
(48, 'Conception de systèmes mécatroniques'),
(49, 'Développement de systèmes distribués'),
(50, 'Développement de jeux en réalité virtuelle ou augmentée'),
(51, 'Java'),
(52, 'Python'),
(53, 'Django'),
(54, 'JavaScript'),
(55, 'React'),
(56, 'Angular'),
(57, 'VueJs'),
(58, 'C#'),
(59, '.NET'),
(60, 'Unity'),
(61, 'PHP'),
(62, 'HTML'),
(63, 'CSS'),
(64, 'SCSS / SASS'),
(65, 'Laravel'),
(66, 'Symphonie'),
(67, 'TypeScript'),
(68, 'C++'),
(69, 'Swift'),
(70, 'Ruby'),
(71, 'Visual Basic'),
(72, 'MySQL'),
(73, 'WinDev');

INSERT INTO `type_users` (`id`, `title`) VALUES
(1, 'Etudiant'),
(2, 'Recruteur'),
(3, 'Directeur');
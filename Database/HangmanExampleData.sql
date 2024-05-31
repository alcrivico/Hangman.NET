INSERT INTO [Category] ([CategoryES], [CategoryEN]) VALUES 
 ('Comida', 'Food'),
 ('Animales', 'Animals'),
 ('Deportes', 'Sports'),
 ('Países', 'Countries'),
 ('Ciudades', 'Cities'),
 ('Películas', 'Movies'),
 ('Música', 'Music'),
 ('Colores', 'Colors'),
 ('Profesiones', 'Professions'),
 ('Objetos', 'Objects');

INSERT INTO [GameStatus] ([Status]) VALUES
    ('Waiting'),
    ('Playing'),
    ('Won'),
    ('Lost'),
    ('Cancelled'),
    ('Left');

INSERT INTO [Language] ([LanguageName]) VALUES
    ('Spanish'), --id 1
    ('English'); -- id 2

INSERT INTO [Player] ([FirstName], [FirstLastName], [SecondLastName], [BirthDate], [Email], [Password]) VALUES
    ('Raul', 'Hernandez', 'Olivares', '2000-06-23', 'raulh230600@gmail.com', '12345'), --id 1
    ('Albhieri', 'Villa', 'Contreras', '2002-12-18', 'alcrivico@gmail.com', 'alcrivico'), --id 2
    ('Miguel', 'Morales', 'Cruz', '2002-08-30', 'moralesmiguelangel176@gmail.com', 'miguelon'), --id 3
    ('Victoria', 'Moyano', '', '1999-01-04', 'soyunpokemonytuno@gmail.com', 'victoria'); --id 4

INSERT INTO [Word] ([WordES], [WordEN], [TipES], [TipEN], [HasNumber], [CategoryId]) VALUES
    ('Pizza', 'Pizza', 'Comida italiana', 'Italian food', 0, 1),
    ('Perro', 'Dog', 'Animal doméstico', 'Domestic animal', 0, 2),
    ('Futbol', 'Soccer', 'Deporte de equipo', 'Team sport', 0, 3),
    ('México', 'Mexico', 'País en América del Norte', 'Country in North America', 0, 4),
    ('Guadalajara', 'Guadalajara', 'Ciudad en México', 'City in Mexico', 0, 5),
    ('Titanic', 'Titanic', 'Película famosa', 'Famous movie', 0, 6),
    ('Rock', 'Rock', 'Género musical', 'Musical genre', 0, 7),
    ('Azul', 'Blue', 'Color primario', 'Primary color', 0, 8),
    ('Doctor', 'Doctor', 'Profesional médico', 'Medical professional', 0, 9),
    ('Mesa', 'Table', 'Mueble con superficie plana', 'Furniture with a flat surface', 0, 10);
--GameCode (pares de digitos): correo del creador + dia + mes + hora + minuto + segundo
INSERT INTO [Game] ([CreationDate], [GameCode], [StatusID], [CreatorID], [WordId], [LanguageId]) VALUES
    ('2021-06-23 12:00:00', 'RA230621120000', 1, 1, 1, 1),
    ('2021-06-23 12:53:22', 'AL230621125322', 1, 2, 2, 1),
    ('2021-06-23 05:45:06', 'MO230621054506', 1, 3, 3, 1),
    ('2021-06-23 13:01:45', 'SO230621130145', 1, 4, 4, 1);
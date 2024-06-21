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

INSERT INTO [GameStatus] ([StatusEn], [StatusEs]) VALUES
    ('Waiting', 'Esperando'),
    ('Playing', 'Jugando'),
    ('Cancelled', 'Cancelado'),
    ('Left', 'Abandonado'),
    ('Won', 'Ganado'),
    ('Lost', 'Perdido');

INSERT INTO [Language] ([LanguageName]) VALUES
    ('Spanish'),
    ('English');

INSERT INTO [Player] ([FirstName], [FirstLastName], [SecondLastName], [BirthDate], [Email], [Password], [Telephone]) VALUES
    ('Raul', 'Hernandez', 'Olivares', '2000-06-23', 'raulh230600@gmail.com', '12345', '2281940630'),
    ('Albhieri', 'Villa', 'Contreras', '2002-12-18', 'alcrivico@gmail.com', 'alcrivico', '2282213736'),
    ('Miguel', 'Morales', 'Cruz', '2002-08-30', 'moralesmiguelangel176@gmail.com', 'miguelon', '2311343356'),
    ('Victoria', 'Moyano', '', '1999-01-04', 'soyunpokemonytuno@gmail.com', 'victoria', '2282728682');

INSERT INTO [Word] ([WordES], [WordEN], [TipES], [TipEN], [HasNumber], [CategoryId]) VALUES
    ('Pizza', 'Pizza', 'Comida italiana', 'Italian food', 0, 1),
    ('Perro', 'Dog', 'Animal doméstico', 'Domestic animal', 0, 2),
    ('Futbol', 'Soccer', 'Deporte de equipo', 'Team sport', 0, 3),
    ('Mexico', 'Mexico', 'País en América del Norte', 'Country in North America', 0, 4),
    ('Guadalajara', 'Guadalajara', 'Ciudad en México', 'City in Mexico', 0, 5),
    ('Titanic', 'Titanic', 'Película famosa', 'Famous movie', 0, 6),
    ('Rock', 'Rock', 'Género musical', 'Musical genre', 0, 7),
    ('Azul', 'Blue', 'Color primario', 'Primary color', 0, 8),
    ('Doctor', 'Doctor', 'Profesional médico', 'Medical professional', 0, 9),
    ('Mesa', 'Table', 'Mueble con superficie plana', 'Furniture with a flat surface', 0, 10),
    ('Taco', 'Taco', 'Comida mexicana', 'Mexican food', 0, 1),
    ('Gato', 'Cat', 'Animal doméstico', 'Domestic animal', 0, 2),
    ('Baloncesto', 'Basketball', 'Deporte de equipo', 'Team sport', 0, 3),
    ('Canada', 'Canada', 'País en América del Norte', 'Country in North America', 0, 4),
    ('Monterrey', 'Monterrey', 'Ciudad en México', 'City in Mexico', 0, 5),
    ('Frozen', 'Frozen', 'Película famosa', 'Famous movie', 0, 6),
    ('Pop', 'Pop', 'Género musical', 'Musical genre', 0, 7),
    ('Rojo', 'Red', 'Color primario', 'Primary color', 0, 8),
    ('Ingeniero', 'Engineer', 'Profesional de la ingeniería', 'Engineering professional', 0, 9),
    ('Silla', 'Chair', 'Mueble para sentarse', 'Furniture for sitting', 0, 10),
    ('Hamburguesa', 'Hamburger', 'Comida rápida', 'Fast food', 0, 1),
    ('Elefante', 'Elephant', 'Animal salvaje', 'Wild animal', 0, 2),
    ('Beisbol', 'Baseball', 'Deporte de equipo', 'Team sport', 0, 3),
    ('Brasil', 'Brazil', 'País en América del Sur', 'Country in South America', 0, 4),
    ('Puebla', 'Puebla', 'Ciudad en México', 'City in Mexico', 0, 5),
    ('Crepusculo', 'Twilight', 'Saga de libros y películas', 'Book and movie saga', 0, 6),
    ('Clasica', 'Classical', 'Género musical', 'Musical genre', 0, 7),
    ('Amarillo', 'Yellow', 'Color primario', 'Primary color', 0, 8),
    ('Abogado', 'Lawyer', 'Profesional del derecho', 'Legal professional', 0, 9);


--GameCode: correo del creador(Primer par de) + dia + mes + hora + minuto + segundo
INSERT INTO [Game] ([CreationDate], [GameCode], [StatusID], [CreatorID], [ChallengerId], [WordId], [LanguageId]) VALUES
    ('2021-06-23 12:00:00', 'RA230621120000', 5, 1, 4, 1, 1),
    ('2021-06-23 12:53:22', 'AL230621125322', 6, 2, 3, 2, 1),
    ('2021-06-23 05:45:06', 'MO230621054506', 5, 3, 2, 3, 1),
    ('2021-06-23 13:01:45', 'SO230621130145', 6, 4, 1, 4, 1),
    ('2021-06-23 13:15:00', 'RA230621131500', 5, 1, 3, 5, 1),
    ('2024-06-15 13:30:00', 'AL150624133000', 5, 2, 4, 6, 1),
    ('2024-06-15 13:45:00', 'MO150624134500', 5, 3, 1, 7, 1);
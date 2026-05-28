USE PalabrerIA;
GO

INSERT INTO tipos_documento (id_tipo, nombre_tipo, descripcion) VALUES
(1, 'Artículo científico/paper', 'Documento académico o científico con lenguaje técnico.'),
(2, 'Guía médica o institucional', 'Documento orientador de una entidad de salud.'),
(3, 'Comunicado de prensa', 'Texto institucional dirigido a medios de comunicación.'),
(4, 'Noticia en medio especializado', 'Artículo periodístico en medio de salud o tecnología.'),
(5, 'Blog institucional', 'Contenido divulgativo publicado por una organización.'),
(6, 'Historia de paciente', 'Narrativa humana relacionada con salud o atención médica.'),
(7, 'Post de redes sociales', 'Contenido breve para redes sociales.'),
(8, 'Material educativo para pacientes', 'Contenido sencillo dirigido a pacientes o cuidadores.');
GO

INSERT INTO temas (id_tema, nombre_tema, descripcion) VALUES
(1, 'Cardiovascular', 'Textos relacionados con corazón, circulación y dispositivos cardiovasculares.'),
(2, 'Diabetes', 'Textos sobre diabetes, insulina, monitoreo y autocuidado.'),
(3, 'Neurociencias', 'Textos sobre cerebro, sistema nervioso y terapias neurológicas.'),
(4, 'Columna y Espalda', 'Textos sobre dolor, cirugía y tratamientos de columna.'),
(5, 'Digestivo y Gastrointestinal', 'Textos sobre aparato digestivo y enfermedades gastrointestinales.'),
(6, 'Urología', 'Textos sobre sistema urinario y salud urológica.'),
(7, 'Oncología', 'Textos sobre cáncer, diagnóstico y tratamientos.'),
(8, 'Salud Pulmonar', 'Textos sobre respiración, pulmones y enfermedades respiratorias.'),
(9, 'Cuidado Renal', 'Textos sobre riñones y tratamientos renales.'),
(10, 'Otorrinolaringología', 'Textos sobre oído, nariz y garganta.'),
(11, 'Fármacos', 'Textos sobre medicamentos y terapias farmacológicas.'),
(12, 'Salud Mental', 'Textos sobre bienestar emocional y salud mental.');
GO

INSERT INTO formato_texto (id_formato, nombre_formato, descripcion) VALUES
(1, 'Texto original', 'Texto fuente sin transformación.'),
(2, 'Traducción a inglés', 'Versión traducida al idioma inglés.'),
(3, 'Traducción a español', 'Versión traducida al idioma español.'),
(4, 'Resumen simplificado', 'Versión resumida para público general.'),
(5, 'Lenguaje claro', 'Versión adaptada a una audiencia no científica.');
GO

INSERT INTO documentos (
    titulo,
    texto_original,
    idioma_original,
    fecha_publicacion,
    fuente,
    id_tipo,
    id_tema,
    nivel_tecnico,
    publico_objetivo,
    url_fuente
)
VALUES
(
    'Avances en dispositivos cardiovasculares para pacientes pediátricos',
    'Los dispositivos cardiovasculares pediátricos permiten tratar alteraciones del ritmo cardíaco en pacientes recién nacidos y niños con condiciones clínicas complejas.',
    'Español',
    '2025-05-01',
    'Corpus académico PalabrerIA',
    1,
    1,
    'Alto',
    'Profesionales de salud',
    NULL
),
(
    'Diabetes and continuous glucose monitoring',
    'Continuous glucose monitoring systems help patients with diabetes understand their glucose levels in real time and support better treatment decisions.',
    'Inglés',
    '2025-05-02',
    'PalabrerIA academic corpus',
    5,
    2,
    'Medio',
    'General audience',
    NULL
),
(
    'Material educativo sobre salud pulmonar',
    'La salud pulmonar depende de hábitos de vida, detección temprana de síntomas respiratorios y acceso oportuno a servicios médicos.',
    'Español',
    '2025-05-03',
    'Corpus académico PalabrerIA',
    8,
    8,
    'Bajo',
    'Pacientes y cuidadores',
    NULL
);
GO

INSERT INTO versiones_texto (
    id_documento,
    id_formato,
    tipo_version,
    texto_version,
    idioma_version
)
VALUES
(
    1,
    4,
    'Resumen simplificado',
    'Algunos niños nacen con problemas en el ritmo del corazón. Los dispositivos cardiovasculares pueden ayudar a controlar esos problemas y mejorar su calidad de vida.',
    'Español'
),
(
    2,
    3,
    'Traducción a español',
    'Los sistemas de monitoreo continuo de glucosa ayudan a las personas con diabetes a conocer sus niveles de azúcar en tiempo real y tomar mejores decisiones sobre su tratamiento.',
    'Español'
),
(
    3,
    2,
    'Traducción a inglés',
    'Lung health depends on healthy habits, early detection of respiratory symptoms, and timely access to medical care.',
    'Inglés'
);
GO

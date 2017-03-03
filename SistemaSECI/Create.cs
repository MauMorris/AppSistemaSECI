
namespace SistemaSECI
{
    class Create
    {
        //string's para crear tablas
        //Aqui se generan todos los string para crear las tablas necesarias en nuestra base de datos.
        //Siempre que se necesite actualizar la base de datos o crear nuevas tablas
        //se hará modificando los strings o creando nuevos strings y modificando la clase ContratoSeci.

        //-----------------------------------------//---------------------------------------------------//
        //string de la tabla de "datos de usuario" 12 STRINGS
        //a partir de la cual se relacionaran las otras tablas.
        //-----------------------------------------//---------------------------------------------------//
        public static readonly string SQL_CREATE_DATOS_USUARIO_TABLE = "CREATE TABLE IF NOT EXISTS " +
                                Contrato.DatosUsuario.TABLE_NAME + " ( " +
                                Contrato.DatosUsuario.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                Contrato.DatosUsuario.CODIGO + " VARCHAR(50), " +
                                Contrato.DatosUsuario.NOMBRE + " VARCHAR(50), " +
                                Contrato.DatosUsuario.APELLIDOS + " VARCHAR(100), " +
                                Contrato.DatosUsuario.EDAD + " INTEGER NOT NULL, " +
                                Contrato.DatosUsuario.ESCOLARIDAD + " VARCHAR(50), " +
                                Contrato.DatosUsuario.SEXO + " VARCHAR(50), " +
                                Contrato.DatosUsuario.TUTOR + " VARCHAR(100), " +
                                Contrato.DatosUsuario.EDAD_TUTOR + " INTEGER NOT NULL, " +
                                Contrato.DatosUsuario.TELEFONO_TUTOR + " VARCHAR(50), " +
                                Contrato.DatosUsuario.MAIL + " VARCHAR(100) ) ";
        //-----------------------------------------//---------------------------------------------------//
        //strings del modulo de alimentacion 10 STRINGS
        //-----------------------------------------//---------------------------------------------------//
        public static readonly string SQL_CREATE_DIETA_DIARIA_TABLE = "CREATE TABLE IF NOT EXISTS " +
                                Contrato.DietaDiaria.TABLE_NAME + " ( " +
                                Contrato.DietaDiaria.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                Contrato.DietaDiaria.DIA_SEMANA + " VARCHAR(20), " +
                                Contrato.DietaDiaria.DESAYUNO + " VARCHAR(100), " +
                                Contrato.DietaDiaria.ALMUERZO + " VARCHAR(100), " +
                                Contrato.DietaDiaria.COMIDA + " VARCHAR(100), " +
                                Contrato.DietaDiaria.MERIENDA + " VARCHAR(100), " +
                                Contrato.DietaDiaria.CENA + " VARCHAR(100), " +
                                Contrato.DietaDiaria.RUBRICA + " INTEGER NOT NULL, " +
                                Contrato.DietaDiaria.COMENTARIOS + " VARCHAR(200)) ";
        //-----------------------------------------//---------------------------------------------------//
        //strings del modulo de calculo de IMC 5 STRINGS
        //-----------------------------------------//---------------------------------------------------//
        public static readonly string SQL_CREATE_IMC_TABLE = "CREATE TABLE IF NOT EXISTS " +
                                Contrato.Imc.TABLE_NAME + " ( " +
                                Contrato.Imc.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                Contrato.Imc.ESTATURA + " DOUBLE, " +
                                Contrato.Imc.PESO + " DOUBLE, " +
                                Contrato.Imc.IMC + " DOUBLE) ";
        //-----------------------------------------//---------------------------------------------------//
        //strings de la tabla de llaves para usuario imc 3 STRINGS
        //-----------------------------------------//---------------------------------------------------//
        public static readonly string SQL_CREATE_LLAVES_USUARIO_IMC_TABLE = "CREATE TABLE IF NOT EXISTS " +
                                Contrato.LlavesUsuarioImc.TABLE_NAME + " ( " +
                                Contrato.LlavesUsuarioImc.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                Contrato.LlavesUsuarioImc.LLAVE_USUARIO + " INTEGER NOT NULL, " +
                                Contrato.LlavesUsuarioImc.LLAVE_IMC + " INTEGER NOT NULL, " +
                                "FOREIGN KEY( " + Contrato.LlavesUsuarioImc.LLAVE_USUARIO + " ) " +
                                "REFERENCES " + Contrato.DatosUsuario.TABLE_NAME + " ( " +
                                                Contrato.DatosUsuario.ID + " ), " +

                                "FOREIGN KEY( " + Contrato.LlavesUsuarioImc.LLAVE_IMC + " ) " +
                                "REFERENCES " + Contrato.Imc.TABLE_NAME + " ( " +
                                                Contrato.Imc.ID + " )) ";
        //-----------------------------------------//---------------------------------------------------//
        //strings de la tabla de llaves para el modulo de alimentacion 6 STRINGS
        //-----------------------------------------//---------------------------------------------------//
        public static readonly string SQL_CREATE_SESION_ALIMENTACION_TABLE = "CREATE TABLE IF NOT EXISTS " +
                                Contrato.SesionAlimentacion.TABLE_NAME + " ( " +
                                Contrato.SesionAlimentacion.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                Contrato.SesionAlimentacion.SESION + "INTEGER NOT NULL, " +
                                Contrato.SesionAlimentacion.DIETA_DIARIA_ID + " INTEGER NOT NULL, " +
                                Contrato.SesionAlimentacion.DATOS_USUARIO_ID + " INTEGER NOT NULL, " +
                                Contrato.SesionAlimentacion.IMC_ID + " INTEGER NOT NULL, " +
                                "FOREIGN KEY( " + Contrato.SesionAlimentacion.DATOS_USUARIO_ID + " ) " +
                                "REFERENCES " + Contrato.DatosUsuario.TABLE_NAME + " ( " +
                                                Contrato.DatosUsuario.ID + " ), " +

                                "FOREIGN KEY( " + Contrato.SesionAlimentacion.IMC_ID + " ) " +
                                "REFERENCES " + Contrato.Imc.TABLE_NAME + " ( " +
                                                Contrato.Imc.ID + " ), " +

                                "FOREIGN KEY( " + Contrato.SesionAlimentacion.DIETA_DIARIA_ID + " ) " +
                                "REFERENCES " + Contrato.DietaDiaria.TABLE_NAME + " ( " +
                                                Contrato.DietaDiaria.ID + " )) ";
        //-----------------------------------------//---------------------------------------------------//
        //strings de la sesion de juego y resultados finales de kinect 6 STRINGS
        //-----------------------------------------//---------------------------------------------------//
        public static readonly string SQL_CREATE_LOGROS_SESION_JUEGO_TABLE = "CREATE TABLE IF NOT EXISTS " +
                                Contrato.LogrosSesionJuego.TABLE_NAME + " ( " +
                                Contrato.LogrosSesionJuego.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                Contrato.LogrosSesionJuego.TIEMPO_JUEGO + " DATETIME, " +
                                Contrato.LogrosSesionJuego.MONEDAS_RECOLECTADAS + " INTEGER NOT NULL, " +
                                Contrato.LogrosSesionJuego.NIVEL + " INTEGER NOT NULL, " +
                                Contrato.LogrosSesionJuego.MOVIMIENTOS_JUEGO_ID + " INTEGER NOT NULL, " +
                                "FOREIGN KEY( " + Contrato.LogrosSesionJuego.MOVIMIENTOS_JUEGO_ID + " ) " +
                                " REFERENCES " + Contrato.MovimientosJuego.TABLE_NAME + " ( " +
                                                Contrato.MovimientosJuego.ID + " )) ";
        //-----------------------------------------//---------------------------------------------------//
        //strings de las movimientos permitidos en el juego de kinect 5 STRINGS
        //-----------------------------------------//---------------------------------------------------//
        public static readonly string SQL_CREATE_MOVIMIENTOS_JUEGO_TABLE = "CREATE TABLE IF NOT EXISTS " +
                                Contrato.MovimientosJuego.TABLE_NAME + " ( " +
                                Contrato.MovimientosJuego.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                Contrato.MovimientosJuego.MOVIMIENTO + " VARCHAR(80), " +
                                Contrato.MovimientosJuego.DESCRIPCION + " TEXT, " +
                                Contrato.MovimientosJuego.DIFICULTAD + " INTEGER NOT NULL ) ";
        //-----------------------------------------//---------------------------------------------------//
        //strings de la tabla de llaves para el resultado de la sesion del juego de kinect 5 STRINGS
        //-----------------------------------------//---------------------------------------------------//
        public static readonly string SQL_CREATE_SESION_KINECT_TABLE = "CREATE TABLE IF NOT EXISTS " +
                                Contrato.SesionKinect.TABLE_NAME + " ( " +
                                Contrato.SesionKinect.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                Contrato.SesionKinect.SESION + " INTEGER NOT NULL, " +
                                Contrato.SesionKinect.LOGROS_SESION_JUEGO_ID + " INTEGER NOT NULL, " +
                                Contrato.SesionKinect.DATOS_USUARIO_ID + " INTEGER NOT NULL, " +
                                "FOREIGN KEY( " + Contrato.SesionKinect.LOGROS_SESION_JUEGO_ID + " ) " +
                                " REFERENCES " + Contrato.LogrosSesionJuego.TABLE_NAME + " ( " +
                                                Contrato.LogrosSesionJuego.ID + " ), " +

                                "FOREIGN KEY( " + Contrato.SesionKinect.DATOS_USUARIO_ID + " ) " +
                                " REFERENCES " + Contrato.DatosUsuario.TABLE_NAME + " ( " +
                                                Contrato.DatosUsuario.ID + " )) ";
        //-----------------------------------------//---------------------------------------------------//
        //strings de las 7(SIETE) tablas para el modulo de seci
        //-----------------------------------------//---------------------------------------------------//
        public static readonly string SQL_CREATE_PARAMETROS_SESION_SECI_TABLE = "CREATE TABLE IF NOT EXISTS " +
                                Contrato.ParametrosSeci.TABLE_NAME + " ( " +
                                Contrato.ParametrosSeci.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                Contrato.ParametrosSeci.REFORZADOR_TIPO + " VARCHAR(50), " +
                                Contrato.ParametrosSeci.REFORZADOR_CLASE + " VARCHAR(50), " +
                                Contrato.ParametrosSeci.INMEDIATEZ_INMEDIATO + " VARCHAR(50), " +
                                Contrato.ParametrosSeci.INMEDIATEZ_DEMORADO + " VARCHAR(50), " +
                                Contrato.ParametrosSeci.ESFUERZO_ALTO + " INTEGER NOT NULL, " +
                                Contrato.ParametrosSeci.ESFUERZO_BAJO + " INTEGER NOT NULL, " +
                                Contrato.ParametrosSeci.PROGRAMA_REF_ALTO + " INTEGER NOT NULL, " +
                                Contrato.ParametrosSeci.PROGRAMA_REF_BAJO + " INTEGER NOT NULL, " +
                                Contrato.ParametrosSeci.NUMERO_SERIES + " INTEGER NOT NULL, " +
                                Contrato.ParametrosSeci.TIPO_SESION + " VARCHAR(50)) ";

        public static readonly string SQL_CREATE_IMAGENES_CALIDAD_ALTA_BAJA_SECI_TABLE = "CREATE TABLE IF NOT EXISTS " +
                                Contrato.ImagenesCalidadAltaBajaSeci.TABLE_NAME + " ( " +
                                Contrato.ImagenesCalidadAltaBajaSeci.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                Contrato.ImagenesCalidadAltaBajaSeci.NOMBRE + " VARCHAR(50), " +
                                Contrato.ImagenesCalidadAltaBajaSeci.URI + " TEXT, " +
                                Contrato.ImagenesCalidadAltaBajaSeci.CALIDAD + " VARCHAR(50), " +
                                Contrato.ImagenesCalidadAltaBajaSeci.TIPO_REFORZADOR_ID + " INTEGER NOT NULL, " +
                                "FOREIGN KEY( " + Contrato.ImagenesCalidadAltaBajaSeci.TIPO_REFORZADOR_ID + " ) " +
                                " REFERENCES " + Contrato.TipoReforzadorSeci.TABLE_NAME + " ( " +
                                                Contrato.TipoReforzadorSeci.ID + " )) ";

        public static readonly string SQL_CREATE_TIPO_REFORZADOR_SECI_TABLE = "CREATE TABLE IF NOT EXISTS " +
                                Contrato.TipoReforzadorSeci.TABLE_NAME + " ( " +
                                Contrato.TipoReforzadorSeci.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                Contrato.TipoReforzadorSeci.REFORZADOR + " VARCHAR(50), " +
                                Contrato.TipoReforzadorSeci.DESCRIPCION + " TEXT ) ";

        public static readonly string SQL_CREATE_IMAGEN_SELECCIONADA_SECI_TABLE = "CREATE TABLE IF NOT EXISTS " +
                                Contrato.ImagenSeleccionadaSeci.TABLE_NAME + " ( " +
                                Contrato.ImagenSeleccionadaSeci.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                Contrato.ImagenSeleccionadaSeci.IMAGEN_SELECCIONADA_ID + " INTEGER NOT NULL, " +
                                Contrato.ImagenSeleccionadaSeci.NUMERO_ELECCIONES + " INTEGER NOT NULL, " +
                               "FOREIGN KEY( " + Contrato.ImagenSeleccionadaSeci.IMAGEN_SELECCIONADA_ID + " ) " +
                                " REFERENCES " + Contrato.ImagenesCalidadAltaBajaSeci.TABLE_NAME + "(" +
                                                Contrato.ImagenesCalidadAltaBajaSeci.ID + " )) ";

        public static readonly string SQL_CREATE_SESION_MUESTREO_SECI_TABLE = "CREATE TABLE IF NOT EXISTS " +
                                Contrato.SesionMuestreoSeci.TABLE_NAME + " ( " +
                                Contrato.SesionMuestreoSeci.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                Contrato.SesionMuestreoSeci.IMAGEN_1 + " VARCHAR(50), " +
                                Contrato.SesionMuestreoSeci.IMAGEN_2 + " VARCHAR(50), " +
                                Contrato.SesionMuestreoSeci.RESULTADO_ID + " VARCHAR(50), " +
                                Contrato.SesionMuestreoSeci.TIEMPO_ELECCION + " DATETIME, " +
                                Contrato.SesionMuestreoSeci.SESION + " INTEGER NOT NULL, " +
                                Contrato.SesionMuestreoSeci.PARAMETROS_SECI_ID + " INTEGER NOT NULL, " +
                                Contrato.SesionMuestreoSeci.DATOS_USUARIO_ID + " INTEGER NOT NULL, " +
                                "FOREIGN KEY( " + Contrato.SesionMuestreoSeci.PARAMETROS_SECI_ID + " ) " +
                                " REFERENCES " + Contrato.ParametrosSeci.TABLE_NAME + " ( " +
                                                Contrato.ParametrosSeci.ID + " ), " +

                                "FOREIGN KEY( " + Contrato.SesionMuestreoSeci.DATOS_USUARIO_ID + " ) " +
                                " REFERENCES " + Contrato.DatosUsuario.TABLE_NAME + " ( " +
                                                Contrato.DatosUsuario.ID + " )) ";

        public static readonly string SQL_CREATE_PRUEBA_SECI_TABLE = "CREATE TABLE IF NOT EXISTS " +
                                Contrato.PruebaSeci.TABLE_NAME + "(" +
                                Contrato.PruebaSeci.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                Contrato.PruebaSeci.CALIDAD_A + " INTEGER NOT NULL, " +
                                Contrato.PruebaSeci.INMEDIATEZ_A + " INTEGER NOT NULL, " +
                                Contrato.PruebaSeci.ESFUERZO_A + " INTEGER NOT NULL, " +
                                Contrato.PruebaSeci.PROGRAMA_REFORZAMIENTO_A + " INTEGER NOT NULL, " +
                                Contrato.PruebaSeci.CALIDAD_B + " INTEGER NOT NULL, " +
                                Contrato.PruebaSeci.INMEDIATEZ_B + " INTEGER NOT NULL, " +
                                Contrato.PruebaSeci.ESFUERZO_B + " INTEGER NOT NULL, " +
                                Contrato.PruebaSeci.PROGRAMA_REFORZAMIENTO_B + " INTEGER NOT NULL, " +
                                Contrato.PruebaSeci.TIEMPO_ELECCION + " DATETIME, " +
                                Contrato.PruebaSeci.RESPUESTA + " INTEGER NOT NULL) ";

        public static readonly string SQL_CREATE_SESION_SECI_TABLE = "CREATE TABLE IF NOT EXISTS " +
                                Contrato.SesionSeci.TABLE_NAME + " ( " +
                                Contrato.SesionSeci.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                Contrato.SesionSeci.SESION + " INTEGER NOT NULL, " +
                                Contrato.SesionSeci.SERIE + " INTEGER NOT NULL, " +
                                Contrato.SesionSeci.PRUEBA + " INTEGER NOT NULL, " +
                                Contrato.SesionSeci.PRUEBA_SECI_ID + " INTEGER NOT NULL, " +
                                Contrato.SesionSeci.PARAMETROS_SECI_ID + " INTEGER NOT NULL, " +
                                Contrato.SesionSeci.DATOS_USUARIO_ID + " INTEGER NOT NULL, " +
                                "FOREIGN KEY( " + Contrato.SesionSeci.PRUEBA_SECI_ID + " ) " +
                                " REFERENCES " + Contrato.PruebaSeci.TABLE_NAME + "  ( " +
                                                Contrato.PruebaSeci.ID + " ), " +

                                "FOREIGN KEY( " + Contrato.SesionSeci.PARAMETROS_SECI_ID + ")" +
                                " REFERENCES " + Contrato.ParametrosSeci.TABLE_NAME + " ( " +
                                                Contrato.ParametrosSeci.ID + " ), " +

                                "FOREIGN KEY( " + Contrato.SesionSeci.DATOS_USUARIO_ID + " ) " +
                                " REFERENCES " + Contrato.DatosUsuario.TABLE_NAME + " ( " +
                                                Contrato.DatosUsuario.ID + " )) ";

    }
}

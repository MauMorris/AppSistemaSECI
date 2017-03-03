
namespace SistemaSECI
{
    public class Contrato
    {
        public sealed class DatosUsuario        //DATOS DEL PACIENTE O USUARIO, STRINGS 12(DOCE)
        {
            public static readonly string TABLE_NAME = "datos_usuario";
            public static readonly string ID = "id";                                        //INTEGER PK AUTOINCREMENT NN
            public static readonly string CODIGO = "codigo_paciente";                       //VARCHAR(50)
            public static readonly string NOMBRE = "nombre";                                //VARCHAR(50)
            public static readonly string APELLIDOS = "apellidos";                          //VARCHAR(100)
            public static readonly string EDAD = "edad";                                    //INTEGER NN
            public static readonly string ESCOLARIDAD = "escolaridad";                      //VARCHAR(50)
            public static readonly string SEXO = "sexo";                                    //VARCHAR(50)
            public static readonly string TUTOR = "nombre_tutor";                           //VARCHAR(50)
            public static readonly string EDAD_TUTOR = "edad_tutor";                        //INTEGER NN
            public static readonly string TELEFONO_TUTOR = "telefono_tutor";                //VARCHAR(50)
            public static readonly string MAIL = "e_mail";                                  //VARCHAR(100)
        }

        public sealed class Imc                 //IMC MEDIDO EN LA SESION, STRINGS 5(CINCO)
        {
            public static readonly string TABLE_NAME = "imc_paciente";
            public static readonly string ID = "id";                                        //INTEGER PK AUTOINCREMENT NN
            public static readonly string PESO = "peso";                                    //DOUBLE
            public static readonly string ESTATURA = "estatura";                            //DOUBLE
            public static readonly string IMC = "imc";                                      //DOUBLE
        }

        public sealed class DietaDiaria         //REGISTRA CONSUMO DE ALIMENTOS EN UN DIA Y LOS COMENTARIOS DE LA CALIDAD, STRINGS 10(DIEZ)
        {
            public static readonly string TABLE_NAME = "dieta_diaria";
            public static readonly string ID = "id";                                        //INTEGER PK AUTOINCREMENT NN
            public static readonly string DIA_SEMANA = "dia_de_la_semana";                  //VARCHAR(20)
            public static readonly string DESAYUNO = "desayuno";                            //VARCHAR(100)
            public static readonly string ALMUERZO = "almuerzo";                            //VARCHAR(100)
            public static readonly string COMIDA = "comida";                                //VARCHAR(100)
            public static readonly string MERIENDA = "merienda";                            //VARCHAR(100)
            public static readonly string CENA = "cena";                                    //VARCHAR(100)
            public static readonly string RUBRICA = "rubrica";                              //INTEGER NN
            public static readonly string COMENTARIOS = "comentarios";                      //VARCHAR(200)
        }

        public sealed class LlavesUsuarioImc         //REGISTRA las llaves de Usuario e Imc, STRINGS 3(TRES)
        {
            public static readonly string TABLE_NAME = "llaves_usuario_imc";
            public static readonly string ID = "id";                                        //INTEGER PK AUTOINCREMENT NN
            public static readonly string LLAVE_USUARIO = "llave_usuario_id";               //INTEGER FK NN
            public static readonly string LLAVE_IMC = "llave_imc_id";                       //INTEGER FK NN
        }

        public sealed class SesionAlimentacion  //TABLA DE LLAVES QUE UNE DATOS DE USUARIO, DIETA DIARIA, IMC y SESION, STRINGS 6(SEIS)
        {
            public static readonly string TABLE_NAME = "sesion_alimentacion";
            public static readonly string ID = "id";                                        //INTEGER PK AUTOINCREMENT
            public static readonly string SESION = "numero_de_sesion";                      //INTEGER NN
            public static readonly string DIETA_DIARIA_ID = "dieta_diaria_id";              //INTEGER FK NN
            public static readonly string DATOS_USUARIO_ID = "datos_del_usuario_id";        //INTEGER FK NN
            public static readonly string IMC_ID = "imc_del_paciente_id";                   //INTEGER FK NN
        }

        public sealed class LogrosSesionJuego   //DATOS ESTADISTICOS DE LA SESION JUGADA, STRINGS 6(SEIS)
        {
            public static readonly string TABLE_NAME = "logros_sesion_juego";
            public static readonly string ID = "id";                                        //INTEGER PK AUTOINCREMENT
            public static readonly string TIEMPO_JUEGO = "tiempo_de_juego";                 //DATETIME
            public static readonly string MONEDAS_RECOLECTADAS = "monedas_recolectadas";    //INTEGER NN
            public static readonly string NIVEL = "nivel";                                  //INTEGER NN
            public static readonly string MOVIMIENTOS_JUEGO_ID = "movimiento_juego_id";     //INTEGER FK NN
        }

        public sealed class MovimientosJuego    //SUBNIVELES (EJERCICIOS) COMPLETOS DE LOS VERTICES CAPTURADOS POR KINECT, STRINGS 5(CINCO)
        {
            public static readonly string TABLE_NAME = "movimientos_juego";
            public static readonly string ID = "id";                                        //INTEGER PK AUTOINCREMENT
            public static readonly string MOVIMIENTO = "movimiento";                        //VARCHAR(80)
            public static readonly string DESCRIPCION = "descripcion";                      //TEXT NN
            public static readonly string DIFICULTAD = "dificultad_juego";                  //INTEGER NN
        }

        public sealed class SesionKinect        //TABLA DE LLAVES DEL JUEGO DE KINECT, STRINGS 5(CINCO)
        {
            public static readonly string TABLE_NAME = "sesion_Kinect";
            public static readonly string ID = "id";                                        //INTEGER PK AUTOINCREMENT
            public static readonly string SESION = "numero_de_sesion";                      //INTEGER NN
            public static readonly string LOGROS_SESION_JUEGO_ID = "logros_sesion_del_juego_id";//INTEGER FK NN
            public static readonly string DATOS_USUARIO_ID = "datos_del_usuario_id";        //INTEGER FK NN
        }

            public sealed class ParametrosSeci  //CONFIGURACION DE LAS DIMENSIONES QUE SE PONEN EN COMPETENCIA, STRINGS 12(DOCE)
        {
            public static readonly string LINEA_BASE = "linea_base";
            public static readonly string EVALUACION = "evaluacion";
            public static readonly string REPLICA = "replica";

            public static readonly string TABLE_NAME = "parametros_seci";
            public static readonly string ID = "id";                                        //INTEGER PK AUTOINCREMENT
            public static readonly string REFORZADOR_TIPO = "tipo_de_reforzador";           //VARCHAR(50)
            public static readonly string REFORZADOR_CLASE = "clase_de_reforzador";         //VARCHAR(50)
            public static readonly string INMEDIATEZ_INMEDIATO = "inmediatez_inmediata";    //VARCHAR(50)
            public static readonly string INMEDIATEZ_DEMORADO = "inmediatez_demorada";      //VARCHAR(50)
            public static readonly string ESFUERZO_ALTO = "esfuerzo_alto";                  //INTEGER NN
            public static readonly string ESFUERZO_BAJO = "esfuerzo_bajo";                  //INTEGER NN
            public static readonly string PROGRAMA_REF_ALTO = "programa_de_reforzamiento_alto";//INTEGER NN
            public static readonly string PROGRAMA_REF_BAJO = "programa_de_reforzamiento_bajo";//INTEGER NN
            public static readonly string TIPO_SESION = "tipo_de_sesion_lb_ev_rep";         //VARCHAR(50)
            public static readonly string NUMERO_SERIES = "numero_de_series";               //INTEGER NN
        }

        public sealed class ImagenesCalidadAltaBajaSeci // STRINGS 6(SEIS)
        {
            public static readonly string CALIDAD_ALTA = "calidad_alta";
            public static readonly string CALIDAD_BAJA = "calidad_baja";

            public static readonly string TABLE_NAME = "imagenes_calidad_alta_baja_seci";
            public static readonly string ID = "id";                                        //INTEGER PK AUTOINCREMENT
            public static readonly string NOMBRE = "nombre_de_la_imagen";                   //VARCHAR(50)
            public static readonly string URI = "localizacion_imagen";                      //TEXT
            public static readonly string CALIDAD = "calidad_alta_baja";                    //VARCHAR(50)
            public static readonly string TIPO_REFORZADOR_ID = "tipo_reforzador_id";        //INTEGER FK NN
        }

        public sealed class TipoReforzadorSeci // STRINGS 4(CUATRO)
        {
            public static readonly string REFORZADOR_COMIDA = "comida";
            public static readonly string DESCRIPCION_COMIDA = "se utilizan cuarenta imágenes de alimentos, " +  
                                                                "veinte de calidad alta(alimentos saludables) " +
                                                                "y veinte de calidad baja(comida chatarra)";

            public static readonly string TABLE_NAME = "tipo_reforzador_seci";
            public static readonly string ID = "id";                                        //INTEGER PK AUTOINCREMENT
            public static readonly string REFORZADOR = "nombre_reforzador";                 //VARCHAR(50)
            public static readonly string DESCRIPCION = "descripcion";                      //TEXT
        }

        public sealed class ImagenSeleccionadaSeci // STRINGS 4(CUATRO)
        {
            public static readonly string TABLE_NAME = "imagen_seleccionada_seci";
            public static readonly string ID = "id";                                        //INTEGER PK AUTOINCREMENT
            public static readonly string IMAGEN_SELECCIONADA_ID = "imagenes_calidad_seci_id";//INTEGER FK NN
            public static readonly string NUMERO_ELECCIONES = "numero_de_elecciones";       //INTEGER NN
        }

        public sealed class SesionMuestreoSeci // STRINGS 9(NUEVE)
        {
            public static readonly string TABLE_NAME = "comparacion_muestreo_seci";
            public static readonly string ID = "id";                                        //INTEGER PK AUTOINCREMENT
            public static readonly string IMAGEN_1 = "i1_imagen_seleccionada";              //VARCHAR(50)
            public static readonly string IMAGEN_2 = "i2_imagen_seleccionada";              //VARCHAR(50)
            public static readonly string RESULTADO_ID = "resultado_imagen_seleccionada";   //VARCHAR(50)
            public static readonly string TIEMPO_ELECCION = "tiempo_de_eleccion";           //DATETIME
            public static readonly string SESION = "numero_sesion";                         //INTEGER NN
            public static readonly string PARAMETROS_SECI_ID = "parametros_sesion_seci_id"; //INTEGER FK NN
            public static readonly string DATOS_USUARIO_ID = "datos_usuario_id";            //INTEGER FK NN
        }

        public sealed class PruebaSeci      // STRINGS 13(TRECE)
        {
            public static readonly string CALIDAD_ALTA = "calidad_alta";                      
            public static readonly string CALIDAD_BAJA = "calidad_baja";                      

            public static readonly string TABLE_NAME = "prueba_seci";
            public static readonly string ID = "id";                                        //INTEGER PK AUTOINCREMENT
            public static readonly string CALIDAD_A = "calidad_a";                          //INTEGER NN
            public static readonly string INMEDIATEZ_A = "inmediatez_a";                    //INTEGER NN
            public static readonly string ESFUERZO_A = "esfuerzo_a";                        //INTEGER NN
            public static readonly string PROGRAMA_REFORZAMIENTO_A = "programa_ref_a";      //INTEGER NN
            public static readonly string CALIDAD_B = "calidad_b";                          //INTEGER NN
            public static readonly string INMEDIATEZ_B = "inmediatez_b";                    //INTEGER NN
            public static readonly string ESFUERZO_B = "esfuerzo_b";                        //INTEGER NN
            public static readonly string PROGRAMA_REFORZAMIENTO_B = "programa_ref_b";      //INTEGER NN
            public static readonly string TIEMPO_ELECCION = "tiempo_para_elegir";           //INTEGER NN
            public static readonly string RESPUESTA = "opcion_elegida_a_vs_b";              //VARCHAR(50)
            public static readonly string RESPPONDIO_PROBLEMA = "respondio_el_problema";    //VARCHAR(50)
        }

        public sealed class SesionSeci          // STRINGS 8(OCHO)
        {
            public static readonly string TABLE_NAME = "sesion_seci";
            public static readonly string ID = "id";                                        //INTEGER PK AUTOINCREMENT
            public static readonly string SESION = "numero_sesion";                         //INTEGER NN
            public static readonly string SERIE = "numero_de_serie";                        //INTEGER NN
            public static readonly string PRUEBA = "numero_de_prueba";                      //INTEGER NN
            public static readonly string PRUEBA_SECI_ID = "ocho_pruebas_serie_seci_id";    //INTEGER FK NN
            public static readonly string PARAMETROS_SECI_ID = "parametros_de_sesion_seci_id";//INTEGER FK NN
            public static readonly string DATOS_USUARIO_ID = "datos_del_usuario_id";        //INTEGER FK NN
        }
    }
}

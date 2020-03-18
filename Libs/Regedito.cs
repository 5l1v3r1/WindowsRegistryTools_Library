﻿using System;
using Microsoft.Win32;  //Librería importante 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryTools.Libs {
    class Regedito {
        string message = "";

        public string createKeyValue_String(string path /*Ruta completa del key*/, string nameValue/*valores de la llave*/, string dataValue /*Datos almacenados del valor*/) {
           
            string typeRegistry = getTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            if (path == "" || nameValue == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;

            try {
                switch (getTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.String);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.String);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.String);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.String);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.String);
                    k.Close();
                    break;

                    default:
                    message = "La ruta ingresada no e tiene un problema ";
                    break;
                }
                return "E#XITO";
            } catch (Exception) {
                return "E#RR04";    // No se puedo crear el valor de la llave
            }
        }

        public string createKeyValue_Binarie(string path /*Ruta completa del key*/, string nameValue/*valores de la llave*/, string dataValue /*Datos almacenados del valor*/) {

            string typeRegistry = getTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            if (path == "" || nameValue == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }

            path = routePath(path);
            try {
                // Ruta // Nombre del valor // Datos del valor 
                Registry.SetValue(path, nameValue, dataValue, RegistryValueKind.String);
                return "E#XITO";
            } catch (Exception) {
                return "E#RR04";    // No se puedo crear el valor de la llave
            }

            RegistryKey k;

            //switch (tipo) {
            //    case "HKEY_CLASSES_ROOT":
            //    k = Registry.CurrentUser.CreateSubKey(ruta_sin_tipo, true);
            //    k.SetValue("BinaryValue", new byte[] { 10, 43, 44, 45, 14, 255 }, RegistryValueKind.Binary);

            //    k.Close();
            //    break;
            //    case "HKEY_CURRENT_USER":
            //    k = Registry.CurrentUser.OpenSubKey(ruta_sin_tipo, true);
            //    // This overload supports QWord (long) values. 
            //    k.SetValue("QuadWordValue", 42, RegistryValueKind.QWord);

            //    // The following SetValue calls have the same effect as using the
            //    // SetValue overload that does not specify RegistryValueKind.
            //    //
            //    k.SetValue("DWordValue", 42, RegistryValueKind.DWord);
            //    k.SetValue("MultipleStringValue", new string[] { "One", "Two", "Three" }, RegistryValueKind.MultiString);
            //    k.SetValue("BinaryValue", new byte[] { 10, 43, 44, 45, 14, 255 }, RegistryValueKind.Binary);
            //    k.SetValue("StringValue", "The path is %PATH%", RegistryValueKind.String);

            //    // This overload supports setting expandable string values. Compare
            //    // the output from this value with the previous string value.
            //    k.SetValue("ExpandedStringValue", "The path is %PATH%", RegistryValueKind.ExpandString);
            //    k.Close();
            //    break;
            //    case "HKEY_LOCAL_MACHINE":
            //    k = Registry.LocalMachine.OpenSubKey(ruta_sin_tipo, true);
            //    k.DeleteValue(nameValue);
            //    k.Close();
            //    break;
            //    case "HKEY_USERS":
            //    k = Registry.Users.OpenSubKey(ruta_sin_tipo, true);
            //    k.DeleteValue(nameValue);
            //    k.Close();
            //    break;
            //    case "HKEY_CURRENT_CONFIG":
            //    k = Registry.CurrentConfig.OpenSubKey(ruta_sin_tipo, true);
            //    k.DeleteValue(nameValue);
            //    k.Close();
            //    break;

            //    default:
            //    message = "Hubo un problema con la ruta ingresada";
            //    break;
            //}


            RegistryKey rk = Registry.CurrentUser.CreateSubKey("RegistryValueKindExample");







            return message;
        }

        public string createKeyValue_DWORD(string path /*Ruta completa del key*/, string nameValue/*valores de la llave*/, Int32 dataValue /*Datos almacenados del valor*/) {
            string typeRegistry = getTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            path = routePath(path);

            if (path == "" || nameValue == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;


            // Verificar si sobrepasó el int32

            // Valor DWORD, número entero no negativo de 32 bits (números entre el 0 y el 4.294.967.295 [232 – 1])






            try {
                switch (getTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.DWord);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.DWord);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.DWord);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.DWord);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.DWord);
                    k.Close();
                    break;

                    default:
                    message = "La ruta ingresada tiene un problema ";
                    break;
                }
                return "E#XITO";
            } catch (Exception) {
                return "E#RR04";    // No se puedo crear el valor de la llave
            }

        }
        ///// path     = Ruta de Regedit de Windows
        ///// nameValue     = Es el nombre que tendrá llave
        ///// dataValue   = Son los valores que almacenará la llave - String
        //string tipo = getTypeRegistry(path);
        //string ruta_sin_tipo = getKeyRutaSingetTypeRegistry(path);

        //RegistryKey k;

        //    switch (tipo) {
        //        case "HKEY_CLASSES_ROOT":
        //        k = Registry.CurrentUser.CreateSubKey(ruta_sin_tipo, true);
        //        k.SetValue("BinaryValue", new byte[] { 10, 43, 44, 45, 14, 255 }, RegistryValueKind.Binary);

        //        k.Close();
        //        break;
        //        case "HKEY_CURRENT_USER":
        //        k = Registry.CurrentUser.OpenSubKey(ruta_sin_tipo, true);
        //        // This overload supports QWord (long) values. 
        //        k.SetValue("QuadWordValue", 42, RegistryValueKind.QWord);

        //        // The following SetValue calls have the same effect as using the
        //        // SetValue overload that does not specify RegistryValueKind.
        //        //
        //        k.SetValue("DWordValue", 42, RegistryValueKind.DWord);
        //        k.SetValue("MultipleStringValue", new string[] { "One", "Two", "Three" }, RegistryValueKind.MultiString);
        //        k.SetValue("BinaryValue", new byte[] { 10, 43, 44, 45, 14, 255 }, RegistryValueKind.Binary);
        //        k.SetValue("StringValue", "The path is %PATH%", RegistryValueKind.String);

        //        // This overload supports setting expandable string values. Compare
        //        // the output from this value with the previous string value.
        //        k.SetValue("ExpandedStringValue", "The path is %PATH%", RegistryValueKind.ExpandString);
        //        k.Close();
        //        break;
        //        case "HKEY_LOCAL_MACHINE":
        //        k = Registry.LocalMachine.OpenSubKey(ruta_sin_tipo, true);
        //        k.DeleteValue(nameValue);
        //        k.Close();
        //        break;
        //        case "HKEY_USERS":
        //        k = Registry.Users.OpenSubKey(ruta_sin_tipo, true);
        //        k.DeleteValue(nameValue);
        //        k.Close();
        //        break;
        //        case "HKEY_CURRENT_CONFIG":
        //        k = Registry.CurrentConfig.OpenSubKey(ruta_sin_tipo, true);
        //        k.DeleteValue(nameValue);
        //        k.Close();
        //        break;

        //        default:
        //        message = "Hubo un problema con la ruta ingresada";
        //        break;
        //    }


        //    RegistryKey rk = Registry.CurrentUser.CreateSubKey("RegistryValueKindExample");







        //    return message;
        public string createKeyValue_QWORD(string path /*Ruta completa del key*/, string nameValue/*valores de la llave*/, Int64 dataValue /*Datos almacenados del valor*/) {
            string typeRegistry = getTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            
            path = routePath(path);

            if (path == "" || nameValue == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;

            try {
                switch (getTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.QWord);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.QWord);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.QWord);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.QWord);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.QWord);
                    k.Close();
                    break;

                    default:
                    message = "La ruta ingresada tiene un problema ";
                    break;
                }
                return "E#XITO";
            } catch (Exception) {
                return "E#RR04";    // No se puedo crear el valor de la llave
            }
        }

        public string createKeyValue_MultiString(string path, string nameValue,  string[] dataValue) {

            //Los valores de cadena no requieren un <Value type> (ver ejemplo), pero backslashes ("\") necesita ser escrita como una doble barra invertida ("\ \")
            //Por ejemplo, para añadir los valores "Value A", "Value B", "Value C", "Value D", "Value E", "Value F", "Value G", "Value H", "Value I", "Value J", and "Value K" a la clave HKLM\SOFTWARE\Microsoft, 


            string typeRegistry = getTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            //              Quieres separar por coma? Usa
            //              string[] arValores = tuTextBox.Text.Split(",");
            //              Con eso tienes los números en un arreglo de strings. Luego usa un for each y parsea cada ítem con TryParse
            //Limpiar path 
            path = routePath(path);

            if (path == "" || nameValue == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;

            try {
                switch (getTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.MultiString);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.MultiString);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.MultiString);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.MultiString);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.MultiString);
                    k.Close();
                    break;

                    default:
                    message = "La ruta ingresada tiene un problema ";
                    break;
                }
                return "E#XITO";
            } catch (Exception) {
                return "E#RR04";    // No se puedo crear el valor de la llave
            }

            //////// Verificar que tipo llave es en swith

            //////try {
            //////    RegistryKey k;
            //////    // Ruta // Nombre del valor // Datos del valor 
            //////    k = Registry.CurrentUser.OpenSubKey(path, true);

            //////    k.SetValue(nameValue, dataValue, RegistryValueKind.MultiString);
            //////    //  Registry.SetValue(path, nameValue, {"Soy; un; dato"} RegistryValueKind.MultiString);
            //////    return "Se gurado corerectamente ";
            //////} catch (Exception) {
            //////    return "No se puedo guarsdar ";    // No se puedo crear el valor de la llave
            //////}

        }

        public string createKeyValue_ExpandString(string path, string nameValue, string dataValue) {        //Función crear llave de Registro en formato ExpandableString
            string typeRegistry = getTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            //              Quieres separar por coma? Usa
            //              string[] arValores = tuTextBox.Text.Split(",");
            //              Con eso tienes los números en un arreglo de strings. Luego usa un for each y parsea cada ítem con TryParse
            //Limpiar path 
            path = routePath(path);

            if (path == "" || nameValue == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;

            try {
                switch (getTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.ExpandString);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.ExpandString);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.ExpandString);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.ExpandString);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(getSubFiles(path), true);
                    k.SetValue(nameValue, dataValue, RegistryValueKind.ExpandString);
                    k.Close();
                    break;

                    default:
                    message = "La ruta ingresada tiene un problema ";
                    break;
                }
                return "E#XITO";
            } catch (Exception) {
                return "E#RR04";    // No se puedo crear el valor de la llave
            }

        }

        public string createKey(string path /*Ruta completa del key*/,string nameKey /*Nombre del Key*/ ) {
            //Verifica algún código de error o advertenciaa
            string typeRegistry = getTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            try {
                //Verificar si el Nombre ingresado está vacío
                if (nameKey == "") {
                    return "E#R005 ";  //
                } else {
                    Registry.SetValue(routePath(path) + @"\" + nameKey, "", "");
                    return "E#XITO";  // Se creó correctamente el contenedor
                }


                
            } catch (Exception) {
                return "E#CR01";    // No pudo crear la llave contenedora
            }
        } 
        public string EliiminarestafuncionalidadpleaseSoloEsDePrueba(string path /*Ruta completa del key*/,  string nameValue/*valores de la llave*/, byte typeValue /*Tipo de value*/) {

            //switch (typeValue) {

            ////    /*          0   =       °Se crea un conteiner no una llave°
            //     *          1   =       String Value
            //     *          2   =       Binarie Value
            //     *          3   =       DWORD (32bits) Value
            //     *          4   =       QWORD (64bits) Value
            //     *          5   =       Multi-String Value
            //     *          6   =       Expandable String                                                           */
                



                



            //    case 1:
            //    //String Value
            //    Registry.SetValue(path, dataValue, RegistryValueKind.String);   // Se crea la llave en el registro
            //    break;

            //    case 2:
            //    Registry.SetValue(path, "", RegistryValueKind.Binary);   // Se crea la llave en el registro
            //    break;

            //    case 3:
            //    Registry.SetValue(path, dataValue, RegistryValueKind.DWord);   // Se crea la llave en el registro
            //    break;

            //    case 4:
            //    Registry.SetValue(path, dataValue, RegistryValueKind.QWord);   // Se crea la llave en el registro
            //    break;

            //    case 5:
            //    Registry.SetValue(path, dataValue, RegistryValueKind.MultiString);   // Se crea la llave en el registro
            //    break;

            //    case 6:
            //    Registry.SetValue(path,  dataValue, RegistryValueKind.ExpandString);   // Se crea la llave en el registro
            //    break;

            //    default:
            //    message = "Especifique el tipo de valor del key";
            //    break;
            //}



            return message;
        }
        public string deleteKey(string path /*camino completa del valor*/) {
            string typeRegistry = getTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            //Se obtiene key 
            if (getkeyName(path) == "") {
                return "E#R004";    //No se encontró el nombre del la llave
            }

            try {
                RegistryKey k;

                switch (getTypeRegistry(path)) {
                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(getsubfilesSinKeyName(path), true);
                    k.DeleteSubKeyTree(getkeyName(path));
                    k.Close();
                    break;
                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(getsubfilesSinKeyName(path), true);
                    k.DeleteSubKeyTree(getkeyName(path));
                    k.Close();
                    break;
                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(getsubfilesSinKeyName(path), true);
                    k.DeleteSubKeyTree(getkeyName(path));
                    k.Close();
                    break;
                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(getsubfilesSinKeyName(path), true);
                    k.DeleteSubKeyTree(getkeyName(path));
                    k.Close();
                    break;
                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(getsubfilesSinKeyName(path), true);
                    k.DeleteSubKeyTree(getkeyName(path));
                    k.Close();
                    break;
                    default:
                    message = "";
                    break;
                }
                return "E#XITO";
            } catch (Exception) {
                return "E#NN01";    // No se encontró la llave , o no se puedo eliminar por permisos 
            }
        }
        public string deleteValues(string path /*camino completa del valor*/, string nameValue /*Nombre del valor*/) {
            
            string typeRegistry = getTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            // Verifica NameValue
            if (nameValue == "") {
                return "E#RR03";    // Mensaje de Error, El nombre ingresado del valor está vacío
            }
            //Limpiando Ruta y obtiene datos
            path = routePath(path);

            try {
                RegistryKey k;
                switch (getTypeRegistry(path)) {
                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(getSubFiles(path), true);
                    k.DeleteValue(nameValue);
                    k.Close();
                    break;
                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(getSubFiles(path), true);
                    k.DeleteValue(nameValue);
                    k.Close();
                    break;
                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(getSubFiles(path), true);
                    k.DeleteValue(nameValue);
                    k.Close();
                    break;
                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(getSubFiles(path), true);
                    k.DeleteValue(nameValue);
                    k.Close();
                    break;
                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(getSubFiles(path), true);
                    k.DeleteValue(nameValue);
                    k.Close();
                    break;

                    default:
                    return "E#R002"; // La ruta ingresada no es válida

                }
                return "E#XITO";
            } catch (Exception) {
                message = "E#RR02";
               
            }





            return message;
        }
        public string getValues(string path /*camino completa del valor*/, string nameValue /*Nombre del valor*/) {
            
            string typeRegistry = getTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry =="E#RR02") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            // Verifica si el NombreValue
            if (nameValue == "") {
                //Verifica si el nombre del Key no esté vacío
                return "E#R003";    // El nombre del valor está vacio
            }

            //Limpiando Ruta y obtiene datos
            path = routePath(path);

            try {


                try {
                    message = (string)Registry.GetValue(path, nameValue, "E#RR02");
                } catch (Exception) {
                    try {
                        int entero = 0;
                        entero = (int)Registry.GetValue(path, nameValue, "E#RR02");
                        message = entero.ToString();
                    } catch (Exception) {
                        long entero = 0;
                        entero = (long)Registry.GetValue(path, nameValue, "E#RR02");
                        message = entero.ToString();
                    }
                }

            } catch (Exception) {
                //Mensaje de error +  su Codigo de error
                message = "E#RR01"; // Hubo un error al leer la llave
            }

            return message;
        }
        public string getSubFiles(string path) {
            //Verifica si la ruta ingresada tiene un formato aceptado
            string typeRegistry = getTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            //Limpiando Ruta y obtiene datos
            path = routePath(path);


            // Tipo de R
            // int inin = .Length;    // Obtiene el número de longuitud de la cadena de caracteres de getTypeRegistry
            int inin = getTypeRegistry(path).Length;

            int ifin = path.Length - inin;                    // Obtiene el número de longuituc de caracteres de la ruta completa

            //Verifica si encontró typeRegistry
            int ver = path.LastIndexOf(getTypeRegistry(path)); //    Busca el typo de registro en la ruta ingresada, 

            if (ver == 0) {
                if (path.Substring(inin, ifin) == @"\") {   //Verifica si la ruta lleva un \ , estó podria causar problemas, por ende se decidió eliminarlo
                    return "";
                } else {
                     inin = getTypeRegistry(path).Length+1;
                     ifin = path.Length - inin;

                    if (ifin == -1) {
                        return "";
                    } else {
                        return path.Substring(inin, ifin);          // Verificar esto , fue con Computer\HKEY_CURRENT_USER
                    }
                }
            } else {
                return path = "E#R002"; // Ruta invalida
            }


        }
        public string getsubfilesSinKeyName(string path) {
            //Verifica posibles mensajes de fallos 
            string typeRegistry = getTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }


            // Evita posible Errores 
            if (getkeyName(path) == "") {
                return "";
            }



            // Numero completo subruta - el nombre del key
            int final = getSubFiles(path).Length - getkeyName(path).Length;

            //Convierte la ruta completa a ruta reducida
            // Solo obtiene las subRutas y no la ruta completa 
            path = getSubFiles(path);
            if (final <= 0 ) {
                return "";  // Significa que no existe SubFiles, la llave está creada directamente en el directorio 
            }

               message =  path.Substring(0, final-1);

            return message;
        }
        public string getkeyName(string path) {
            string typeRegistry = getTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            path = getSubFiles(path);

            /* Ésta función busca retornar el "CONTENEDOR" de la variable °path°
             * 
             * =Ejemplo:
             * [Antes]    path = @"HKEY_CURRENT_USER\Contenedor1\Contenedor2\Contenedor3"
             * [Despues]  path =  "Contenedor3"
             * 
             */
            if (path == "") {
                //Verifica si La Ruta ingresada no esté vacío
                return message = "E#R001";
            }

            try {
                /* Utiliza la variable para obtener el ultimo contendor 
                 * =Ejemplo:
                 * [Antes]    path = @"Contenedor1\Contenedor2\Contenedor3" 
                 * [Despues]  path =  "Contenedor3"                                                     */
                int palabraClave = path.LastIndexOf(@"\");
                path = path.Substring(palabraClave + 1);
                if (path == @"\") {
                    return path = "";
                } else {
                    return path;
                }

                
            } catch (Exception) {
                
                message = ""; //Retornará vacío ya que no se encuentra 
            }

            return message;
        }
        public string getTypeRegistry(string path) {
            /* 
             * Ésta función recorrerá toda la variable °path°
             * y retornará solo uno de los siguientes textos:
             *                                        =>        HKEY_CLASSES_ROOT
             *                                        =>        HKEY_CURRENT_USER
             *                                        =>        HKEY_LOCAL_MACHINE
             *                                        =>        HKEY_USERS
             *                                        =>        HKEY_CURRENT_CONFIG                                            
             * VARIABLES:
             *            - String: palabra_inicial     // Desde esta palabra Clave se empieza a obtener el texto
             *            - String: palabra_fin         // Desde esta palabra Clave se termina de obtener el texto
             */


            // Verifica si el camino de ruta lleva Computer\ o computadora
            // bool containsSearchResult = factMessage.Contains("Extension");
            // Console.WriteLine($"Starts with \"extension\"? {containsSearchResult}");

            // verifica si camino lleva computer , pero esta devuelve un valor contrario que el de arriba
            //bool ignoreCaseSearchResult = factMessage.StartsWith("extension", System.StringComparison.CurrentCultureIgnoreCase);
            //Console.WriteLine($"Starts with \"extension\"? {ignoreCaseSearchResult} (ignoring case)");


            // Obtiene la Ruta Limpia
            path = routePath(path);
            // Verifica si la ruta está vacía
            if (path == "E#R001") {
                return path;    //Se termina el proceso y Retorna mensaje de Error
            }


            // Proceso de Obtención de  del tipo de registro

            int ifin;
            int inin;


            inin = path.IndexOf("HKEY_");
            if (inin == -1) {
                return "E#R002";  //Mensaje de error - ruta invalidad
            }


            int root = path.IndexOf(@"HKEY_CLASSES_ROOT") - inin; //Ingles UK
            
            if (root != -1) {
                // Significa que si se encontró ésta palabra
                ifin = @"HKEY_CLASSES_ROOT".Length;
                
                return path.Substring(inin, ifin);
            }
            int user = path.IndexOf(@"HKEY_CURRENT_USER") - inin; //Ingles UK
            if (user != -1) {
                // Significa que si se encontró ésta palabra
                ifin = @"HKEY_CURRENT_USER".Length;
                
                return path.Substring(inin, ifin);
            }
            int machine = path.IndexOf(@"HKEY_LOCAL_MACHINE") - inin; //Ingles UK
            if (machine != -1) {
                // Significa que si se encontró ésta palabra
                ifin = @"HKEY_LOCAL_MACHINE".Length;
                
                return path.Substring(inin, ifin);
            }
            int users = path.IndexOf(@"HKEY_USERS") - inin; //Ingles UK
            if (users != -1) {
                // Significa que si se encontró ésta palabra
                ifin = @"HKEY_USERS".Length;
                
                return path.Substring(inin, ifin);
            }
            int config = path.IndexOf(@"HKEY_CURRENT_CONFIG") - inin; //Ingles UK
            if (config != -1) {
                // Significa que si se encontró ésta palabra
                ifin = @"HKEY_CURRENT_CONFIG".Length;
                
                return path.Substring(inin, ifin);
            }

            if (root == -1 && user == -1 && machine == -1 && users == -1 && config == -1) {
                return "E#R002";   // Manda mensaje de error de ruta no valida
            }


            return "E#R002";   // Manda mensaje de error de ruta no valida

            }   // Funcional sin bugs
        public string routePath(string path) {
            // Ésta función solo devuelve la ruta sin las palabras  Equipo\ && Computer\
            // Y solo detectará si la ruta ingresada está vacía

            if (path == "") {
                //Verifica si La Ruta ingresada no esté vacío
                return message = "E#R001";  // Error la ruta ingresada está vacía
            }


            int nini;              // Número de caracter de Inicio
            int nfin = path.Length; // Número de caracter Final

            //Si no existe la palabra - int ver  = -1
            int ver1 = path.IndexOf(@"Computer\"); //Ingles UK

            //Si no existe la palabra - int ver  = -1
            int ver2 = path.IndexOf(@"Equipo\");   //Español

            if (ver2 != -1) {
                // Significa que si se encontró ésta palabra
                nini = @"Equipo\".Length;
                nfin = nfin - nini;
                return path = path.Substring(nini, nfin);
            }
            if (ver1 != -1) {
                // Significa que si se encontró ésta palabra
                nini = @"Computer\".Length;
                nfin = nfin - nini;
                return path = path.Substring(nini, nfin);
            }
            //if (ver == -1 && ver2 == -2) {
            //    return "";
            //}
            return path;

           
            

        }         // Funcional sin bugs 
    }
}

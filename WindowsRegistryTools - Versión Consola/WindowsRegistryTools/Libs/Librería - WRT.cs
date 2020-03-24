﻿using System;
using Microsoft.Win32;  //Librería importante 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

    class RegistryTools {
    string message = "";

        public String CreateKeyValue_String(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/, string valueData /*Datos almacenados del valor*/) {

            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            if (path == "" || valueName == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;

            try {
                switch (GetTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.String);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.String);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.String);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.String);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.String);
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
        public String CreateKeyValue_Binary(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/, byte [] valueData /*Datos almacenados del valor*/) {
            //los datos deben ser guardadas en binario
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            if (path == "" || valueName == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;

            try {
                switch (GetTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.Binary);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.Binary);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.Binary);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.Binary);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.Binary);
                    k.Close();
                    break;

                    default:
                    message = "La ruta ingresada tiene un problema ";
                    break;
                }
                return "E#XITO";
            } catch  {
                return "E#RR04";    // No se puedo crear el valor de la llave
            }
        }
        public String CreateKeyValue_DWORD(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/, Int32 valueData /*Datos almacenados del valor*/) {
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            path = RoutePath(path);

            if (path == "" || valueName == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;


            // Verificar si sobrepasó el int32

            // Valor DWORD, número entero no negativo de 32 bits (números entre el 0 y el 4.294.967.295 [232 – 1])



            try {
                switch (GetTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.DWord);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.DWord);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.DWord);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.DWord);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.DWord);
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
        public String CreateKeyValue_QWORD(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/, Int64 valueData /*Datos almacenados del valor*/) {
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            path = RoutePath(path);

            if (path == "" || valueName == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;

            try {
                switch (GetTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.QWord);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.QWord);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.QWord);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.QWord);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.QWord);
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
        public String CreateKeyValue_MultiString(string path/*Ruta completa del key*/, string valueName/*valores de la llave*/, string [] valueData/*Datos almacenados del valor*/) {

            //Los valores de cadena no requieren un <Value type> (ver ejemplo), pero backslashes ("\") necesita ser escrita como una doble barra invertida ("\ \")
            //Por ejemplo, para añadir los valores "Value A", "Value B", "Value C", "Value D", "Value E", "Value F", "Value G", "Value H", "Value I", "Value J", and "Value K" a la clave HKLM\SOFTWARE\Microsoft, 


            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            //              Quieres separar por coma? Usa
            //              string[] arValores = tuTextBox.Text.Split(",");
            //              Con eso tienes los números en un arreglo de strings. Luego usa un for each y parsea cada ítem con TryParse
            //Limpiar path 
            path = RoutePath(path);

            if (path == "" || valueName == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;

            try {
                switch (GetTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.MultiString);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.MultiString);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.MultiString);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.MultiString);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.MultiString);
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
        public String CreateKeyValue_ExpandString(string path/*Ruta completa del key*/, string valueName/*valores de la llave*/, string valueData/*Datos almacenados del valor*/) {        //Función crear llave de Registro en formato ExpandableString
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            //              Quieres separar por coma? Usa
            //              string[] arValores = tuTextBox.Text.Split(",");
            //              Con eso tienes los números en un arreglo de strings. Luego usa un for each y parsea cada ítem con TryParse
            //Limpiar path 
            path = RoutePath(path);

            if (path == "" || valueName == "") {    //Verifica si el nombre del valor no esté vacío
                //
                return "E#R003";    //Manda mensaje de error
            }
            RegistryKey k;

            try {
                switch (GetTypeRegistry(path)) {

                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.ExpandString);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.ExpandString);
                    k.Close();
                    break;

                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.ExpandString);
                    k.Close();
                    break;

                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.ExpandString);
                    k.Close();
                    break;

                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(GetSubFiles(path), true);
                    k.SetValue(valueName, valueData, RegistryValueKind.ExpandString);
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
        public String CreateKey(string path /*Ruta completa del key*/, string keyName /*Nombre del Key*/ ) {
            //Verifica algún código de error o advertenciaa
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            try {
                //Verificar si el Nombre ingresado está vacío
                if (keyName == "") {
                    return "E#R005 ";  //
                } else {
                    Registry.SetValue(RoutePath(path) + @"\" + keyName, "", "");
                    return "E#XITO";  // Se creó correctamente el contenedor
                }



            } catch (Exception) {
                return "E#CR01";    // No pudo crear la llave contenedora
            }
        }
        public String DeleteKey(string path /*camino completa del valor*/) {
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }

            //Se obtiene key 
            if (GetkeyName(path) == "") {
                return "E#R004";    //No se encontró el nombre del la llave
            }

            try {
                RegistryKey k;

                switch (GetTypeRegistry(path)) {
                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(GetSubFilesSinKeyName(path), true);
                    k.DeleteSubKeyTree(GetkeyName(path));
                    k.Close();
                    break;
                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(GetSubFilesSinKeyName(path), true);
                    k.DeleteSubKeyTree(GetkeyName(path));
                    k.Close();
                    break;
                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(GetSubFilesSinKeyName(path), true);
                    k.DeleteSubKeyTree(GetkeyName(path));
                    k.Close();
                    break;
                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(GetSubFilesSinKeyName(path), true);
                    k.DeleteSubKeyTree(GetkeyName(path));
                    k.Close();
                    break;
                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(GetSubFilesSinKeyName(path), true);
                    k.DeleteSubKeyTree(GetkeyName(path));
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
        public String DeleteValue(string path /*camino completa del valor*/, string valueName /*Nombre del valor*/) {

            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            // Verifica NameValue
            if (valueName == "") {
                return "E#RR03";    // Mensaje de Error, El nombre ingresado del valor está vacío
            }
            //Limpiando Ruta y obtiene datos
            path = RoutePath(path);

            try {
                RegistryKey k;
                switch (GetTypeRegistry(path)) {
                    case "HKEY_CLASSES_ROOT":
                    k = Registry.ClassesRoot.OpenSubKey(GetSubFiles(path), true);
                    k.DeleteValue(valueName);
                    k.Close();
                    break;
                    case "HKEY_CURRENT_USER":
                    k = Registry.CurrentUser.OpenSubKey(GetSubFiles(path), true);
                    k.DeleteValue(valueName);
                    k.Close();
                    break;
                    case "HKEY_LOCAL_MACHINE":
                    k = Registry.LocalMachine.OpenSubKey(GetSubFiles(path), true);
                    k.DeleteValue(valueName);
                    k.Close();
                    break;
                    case "HKEY_USERS":
                    k = Registry.Users.OpenSubKey(GetSubFiles(path), true);
                    k.DeleteValue(valueName);
                    k.Close();
                    break;
                    case "HKEY_CURRENT_CONFIG":
                    k = Registry.CurrentConfig.OpenSubKey(GetSubFiles(path), true);
                    k.DeleteValue(valueName);
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
        public String GetDataValues(string path /*camino completa del valor*/, string valueName /*Nombre del valor*/) {

            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            // Verifica si el NombreValue
            if (valueName == "") {
                //Verifica si el nombre del Key no esté vacío
                return "E#R003";    // El nombre del valor está vacio
            }

            //Limpiando Ruta y obtiene datos
            path = RoutePath(path);

            //Obtiene string        - ok 
            //Obtiene MultiString   - Error 

            try {

                // Intenta Int32
                try {       
                    Int32 Int32Values = (Int32) Registry.GetValue(path, valueName, "E#RR02");
                    return Int32Values.ToString();
                } catch { 
                    //No es un int32
                }

                // Intenta Int64
                try {       
                    Int64 Int64Values = (Int64) Registry.GetValue(path, valueName, "E#RR02");
                    return Int64Values.ToString();
                } catch {
                    // No se pudo
                }

                // Intenta multistring 
                try {
                    string [] tArray = (string []) Registry.GetValue(path, valueName, new string [] {"E#RR02"});
                        // Leer Array 

                        ArrayList vector1;
                        vector1 = new ArrayList();

                        String salida = "";
                        String salida2 = "";

                        for (int i = 0; i < tArray.Length; i++) {
                            vector1.Add(tArray [i]);

                            salida = String.Join(" ", vector1 [i]);

                            salida2 = salida2 + "\r\n" + salida;

                        }

                        return salida2;
                } catch {
                    // No es 
                }

            //// Insertar los datos en un String 
            message = (string) Registry.GetValue(path, valueName, "E#RR02");
            return message;


        } catch {
                //Mensaje de error +  su Codigo de error
                message = "E#RR01"; // Hubo un error al leer la llave
            }

            return message;
        }



        public String getDataValue_String(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/) {
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            // Verifica si el NombreValue
            if (valueName == "") {
                //Verifica si el nombre del Key no esté vacío
                return "E#R003";    // El nombre del valor está vacio
            }

            //Limpiando Ruta y obtiene datos
            path = RoutePath(path);


            message = (string) Registry.GetValue(path, valueName, "E#RR02");
            return message;

        }
        public byte [] getDataValue_Binary(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/) {
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02") { //Verifica si alguna función retorno algún código de Error
                                                                                                                                                            //weekDays [1]=  { "Sun"};
                return new byte [] {  };
            }
            // Verifica si el NombreValue
            if (valueName == "") {
                //Verifica si el nombre del Key no esté vacío
                return new byte [] {  };    // El nombre del valor está vacio
            }

            //Limpiando Ruta y obtiene datos
            path = RoutePath(path);

            byte [] valueData = (byte []) Registry.GetValue(path, valueName, new byte []{ });



            return valueData;
        }
        public Int32 getDataValue_DWORD(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/) {
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02") { //Verifica si alguna función retorno algún código de Error
                return -000001;
            }
            // Verifica si el NombreValue
            if (valueName == "") {
                //Verifica si el nombre del Key no esté vacío
                return -000003;    // El nombre del valor está vacio
            }

            //Limpiando Ruta y obtiene datos
            path = RoutePath(path);


            Int32 Int32Values = (Int32) Registry.GetValue(path, valueName, -000002);

            return Int32Values;

        }
        public Int64 getDataValue_QWORD(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/) {
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02") { //Verifica si alguna función retorno algún código de Error
                return -000001;
            }
            // Verifica si el NombreValue
            if (valueName == "") {
                //Verifica si el nombre del Key no esté vacío
                return -000003;    // El nombre del valor está vacio
            }
            //Limpiando Ruta y obtiene datos
            path = RoutePath(path);

            Int64 Int64Values = (Int64) Registry.GetValue(path, valueName, -000002);
            return Int64Values;

        }
        public String [] getDataValue_MultiString(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/) {
           
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02") { //Verifica si alguna función retorno algún código de Error
                //weekDays [1]=  { "Sun"};
                return new string [1] { typeRegistry };
            }
            // Verifica si el NombreValue
            if (valueName == "") {
                //Verifica si el nombre del Key no esté vacío
                return new string [1] { "E#R003" };    // El nombre del valor está vacio
            }

            //Limpiando Ruta y obtiene datos
            path = RoutePath(path);

            ArrayList vector1;
            vector1 = new ArrayList();

            string [] tArray = (string []) Registry.GetValue(path, valueName, new string [] { "E#RR02" });
            // Leer Array 

            
            //Codigo comentado , mandará 
            //String salida = "";
            //String salida2 = "";

            //for (int i = 0; i < tArray.Length; i++) {
            //    vector1.Add(tArray [i]);

            //    //salida = String.Join(" ", vector1 [i]);

            //    //salida2 = salida2 + "\r\n" + salida;

            //}

            return tArray;

           
        }
        public String getDataValue_ExpandString(string path /*Ruta completa del key*/, string valueName/*valores de la llave*/) {

            //llama a la función getValueString y obtiene los valores
            message = getDataValue_String(path, valueName);
     
            return message;
        }


        private String GetSubFiles(string path) {
            //Verifica si la ruta ingresada tiene un formato aceptado
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            //Limpiando Ruta y obtiene datos
            path = RoutePath(path);


            // Tipo de R
            // int inin = .Length;    // Obtiene el número de longuitud de la cadena de caracteres de GetTypeRegistry
            int inin = GetTypeRegistry(path).Length;

            int ifin = path.Length - inin;                    // Obtiene el número de longuituc de caracteres de la ruta completa

            //Verifica si encontró typeRegistry
            int ver = path.LastIndexOf(GetTypeRegistry(path)); //    Busca el typo de registro en la ruta ingresada, 

            if (ver == 0) {
                if (path.Substring(inin, ifin) == @"\") {   //Verifica si la ruta lleva un \ , estó podria causar problemas, por ende se decidió eliminarlo
                    return "";
                } else {
                     inin = GetTypeRegistry(path).Length+1;
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
        private String GetSubFilesSinKeyName(string path) {
            //Verifica posibles mensajes de fallos 
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }


            // Evita posible Errores 
            if (GetkeyName(path) == "") {
                return "";
            }



            // Numero completo subruta - el nombre del key
            int final = GetSubFiles(path).Length - GetkeyName(path).Length;

            //Convierte la ruta completa a ruta reducida
            // Solo obtiene las subRutas y no la ruta completa 
            path = GetSubFiles(path);
            if (final <= 0 ) {
                return "";  // Significa que no existe SubFiles, la llave está creada directamente en el directorio 
            }

               message =  path.Substring(0, final-1);

            return message;
        }
        private String GetkeyName(string path) {
            string typeRegistry = GetTypeRegistry(path);
            if (typeRegistry == "E#R001" || typeRegistry == "E#R002" || typeRegistry == "E#R003" || typeRegistry == "E#RR01" || typeRegistry == "E#RR02" || typeRegistry == "E#RR03") { //Verifica si alguna función retorno algún código de Error
                return typeRegistry;
            }
            path = GetSubFiles(path);

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

                
            } catch  {
                
                message = ""; //Retornará vacío ya que no se encuentra 
            }

            return message;
        }
        private String GetTypeRegistry(string path) {
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
            path = RoutePath(path);
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
        private String RoutePath(string path) {
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

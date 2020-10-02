﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MPS.SharedAPIModel.Seguridad
{
    public class Respuesta
    {
        public string ESTATUS { get; set; }
        public string DESCRIPCION { get; set; }
        public string GUID { get; set; }
        public string FOLIO { get; set; }
        public DateTime FECHA { get; set; }
        public object ATRIBUTO1 { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Ventas
    {
        private int ven_codigo;
        private Usuarios usuario;
        private MediosPago medioPago;
        private DateTime ven_fecha;
        //ven_fecha_requerida
        //ven_fecha_envio
        private Decimal ven_total_facturado;
        private Estados estado;


        public Ventas() { }

        public int GetCodigo() { return ven_codigo; }
        public Usuarios GetUsuario() { return usuario; }
        public MediosPago GetMedioPago() { return medioPago; }
        public DateTime GetFecha() {return ven_fecha; }
        public Decimal GetTotalFacturado() { return ven_total_facturado; }
        public Estados GetEstado() { return estado; }

        //SETS
        public void SetCodigo(int ven_codigo) { this.ven_codigo= ven_codigo; }
        public void SetUsuario(Usuarios usuario) { this.usuario = usuario;}
        public void SetMedioPago(MediosPago medioPago) { this.medioPago = medioPago; }
        public void SetFecha (DateTime ven_fecha) { this.ven_fecha = ven_fecha; }
        public void SetTotalFacturado(Decimal ven_total_facturado) { this.ven_total_facturado = ven_total_facturado; }
        public void SetEstado(Estados estado) { this.estado = estado; }
    }
}

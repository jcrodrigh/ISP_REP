interface NavAttributes {
  [propName: string]: any;
}

interface NavWrapper {
  attributes: NavAttributes;
  element: string;
}

interface NavBadge {
  text: string;
  variant: string;
}

interface NavLabel {
  class?: string;
  variant: string;
}

export interface NavData {
  name?: string;
  url?: string;
  icon?: string;
  badge?: NavBadge;
  title?: boolean;
  children?: NavData[];
  variant?: string;
  attributes?: NavAttributes;
  divider?: boolean;
  class?: string;
  label?: NavLabel;
  wrapper?: NavWrapper;
}

export const navItems: NavData[] = [
  {
    name: 'BlackBoard',
    url: '/dashboard',
    class:'backboard',
    
    /*icon: 'icon-speedometer',
    badge: {
      variant: 'info',
      text: 'OK'
    }*/
  },
  /*{
    title: true,
    name: 'Capture'
  },*/
  {
    name: 'Capture',
    url: '/DocumentosPago',
    icon: 'fa fa-angle-double-right',
    class:'cesar',
    //class:'cesar',
    
    children: [
      {
        name: 'Ingreso Individual',
        url: '/DocumentosPago/formulario',
        icon: 'fa fa-keyboard-o',
        class:'cesar'
      },
      {
        name: 'Ingreso Masivo (Excel)',
        url: '/DocumentosPago/excel',
        icon: 'fa fa-file-excel-o'
      },
      {
        name: 'Resumen de Documentos',
        url: '/DocumentosPago/tabla',
        icon: 'fa fa-table'
      }
    ]
  },
  {
    divider:true,
    
  },
  {
    name: 'Verify',
    url: '/AdminIVM',
    icon: 'fa fa-angle-double-right',
    
    children:[
      {
        name: 'Documentos por Validar',
        url: '/AdminIVM/resumen',
        icon: 'fa fa-check',
      },
      {
        name:'Documentos Rechazados',
        url:'/AdminIVM/TablaErrores',
        icon:'fa fa-close '
      },
    ]
  },

 /* {
    title: true,
    name: 'Transfer'
  },*/
  {
    divider:true,
  },
  {
    name: 'Transfer',
    url: '/Transfer',
    icon: 'fa fa-angle-double-right',
    
    children:[
      {
        name: 'Documentos transferidos',
        url: '/transfer/tabla',
        icon: 'fa fa-check',
      },
      /*{
        name: 'Tabla Total',
        url: '/transfer/tablaTotal',
        icon: 'fa fa-check',
        
      },
      /*{
        name:'Documentos Errados',
        url:'/AdminIVM/TablaErrores',
        icon:'fa fa-close '
      },*/
    ]
  },
  {
    divider:true,
  },
  {
    name: 'Reportes',
    url: '/reporting',
    icon: 'fa fa-angle-double-right',
    
    children:[
      {
        name: 'Ranking de Doc. / Costo',
        url: '/reporting/ranking',
        icon: 'fa fa-check',
        
      },
      {
        name: 'Ciclo Documentario',
        url: '/reporting/DocumentaryCycle',
        icon: 'fa fa-check',
      },
      {
        name: 'Gestión de Documentos',
        url: '/reporting/DocumentManagement',
        icon: 'fa fa-check',
        
      },
     
      /*{
        name:'Documentos Errados',
        url:'/AdminIVM/TablaErrores',
        icon:'fa fa-close '
      },*/
    ]
  },
  {
    divider:true,
  },
  {
    name: 'Salir',
    url: '/user',
    icon: 'fa fa-angle-double-right',
  }
 
  /*{
    title: true,
    name: 'Soy Cliente'
  }*/
];

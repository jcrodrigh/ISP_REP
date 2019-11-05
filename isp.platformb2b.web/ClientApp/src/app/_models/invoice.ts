export class Invoice {

    constructor(      
      public TipoDocumento: string,
      public TipoMoneda: string,
      public FechaEmision: Date,
      public HoraEmision: string,
      public FacturaId: string,
    ) {  }
  
  }

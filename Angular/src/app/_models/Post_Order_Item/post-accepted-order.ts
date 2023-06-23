export class PostAcceptedOrder {
  constructor(
    public Description:string="",
    public FinalPrice:number=0,
    public QuantityUnit:string="",
    public Quantity:number=0,
    public PreparationTime:Date,
    public AdditionalInfo:string="",
    public PostId:Number=-1,
    public ProposalId: Number=0,
    public ChefId:string="1",
    public UserId:string="+201234567810",
    ){}
  }

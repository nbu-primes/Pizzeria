export class OrderHistory {
  public orderId: String;
  public orderedAt: Date;
  public price: number;
  public caterer: String;

  public recipes: ShortRecipe[];
  public additives: ShortAddtive[];
}

export class ShortRecipe {
  public name: String;
  public description: String;
  public price: number;
  public ingredients: String[];
}

export class ShortAddtive {
  public name: String;
  public price: Number;
  public count: Number;
}

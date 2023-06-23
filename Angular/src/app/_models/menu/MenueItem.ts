export class MenueItem {
  constructor(
    public name: string,
    public id: number,
    public media: string,
    public description: string,
    public unitPrice: number,
    public prepTime: number,
    public availability: string,
    public likes: number,
    public chefId: string,
    public category: string
  ) {}
}

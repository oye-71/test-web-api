export interface Ordinateur {
    name: string
    brand: string
    price: number
}

export interface OrdinateurDto extends Ordinateur{
    id: string
}
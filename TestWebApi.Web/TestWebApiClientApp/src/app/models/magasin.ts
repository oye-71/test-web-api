import { OrdinateurDto } from "./ordinateur"

export interface Magasin {
    name: string
    location: string
}

export interface MagasinDto extends Magasin {
    id: string
}

export interface MagasinWithComputers extends MagasinDto {
    ordinateurs: OrdinateurDto[]
}
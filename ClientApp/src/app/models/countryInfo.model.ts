import { Link } from "./link.model";

export class CountryInfo {
    constructor(
        public id?: number,
        public countryName?: string,
        public capitalName?: string,
        public links?: Link[]
    ) { }
}
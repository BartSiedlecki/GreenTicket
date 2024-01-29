const isProduction = false;

// System setting
export const serviceCostRate = 0.03;

// Main page
export const noOfNewestEvents = 10;

export const baseApiUrl = isProduction ? 'https://green-ticket.pl/api' : 'https://localhost:7144/api';


interface Config {
    noOfCardsInBlock: number,
    facebookAddress: string,
    instagramAddress: string,
    twitterAddress: string,
    contactPhone: string,
    contactEmail: string,
}

export const config: Config = {
    noOfCardsInBlock: 10,
    facebookAddress: "https://www.facebook.com/greenticket",
    instagramAddress: "https://www.instagram.com/greenticket",
    twitterAddress: "https://www.twitter.com/greenticket",
    contactPhone: "555-555-555",
    contactEmail: "contact@greenticket.pl",
}


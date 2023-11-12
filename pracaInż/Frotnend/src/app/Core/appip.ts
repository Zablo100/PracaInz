const host = "224";
const local = "localhost:7096";
const myip = `192.168.1.${host}:4040`;

export const app = {
    ip: `${local}`
};

export function getErrorMessage(err: any){
    if (err.error.description != undefined){
        return err.error.description
    }

    return "Błąd serwera!"
}

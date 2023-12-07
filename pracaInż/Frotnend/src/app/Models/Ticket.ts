export interface TicketDTO {
    id: number;
    description: string;
    status: number;
    createdAt: string;
    acceptedAt: string;
    resolvedAt: string;
    submittedBy: string;
    submittedByDepartment: string;
    acceptedBy: string;
    computer: string;
    computerId: number | null;
    comments: Comment[] | null;
}

export interface Comment{
    text: string;
    date: string;
}
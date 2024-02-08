export interface PaginationResponse<T> {
    page: number;
    pageSize: number;
    totalCount: number;
    value: T;
}
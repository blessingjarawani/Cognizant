export interface IResponse<T> {
    isSuccess: boolean;
    message: string;
    result: T;
}
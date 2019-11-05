export class ResultMessage<T>{

    public static RESULT_CODE_OK: number = 0;
    public static RESULT_CODE_ERROR: number = 1;
    
    content: T;
    message: string;
    code: number;
}
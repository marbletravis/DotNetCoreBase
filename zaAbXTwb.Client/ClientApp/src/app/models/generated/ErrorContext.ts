
export class ErrorContext {
	public Error: any ;
	public Handled: boolean ;
	public Member: any ;
	public OriginalObject: any ;
	public Path: string ;

	public constructor(
		fields?: Partial<ErrorContext>) {

		if (fields) {



			Object.assign(this, fields);
		}
	}
}

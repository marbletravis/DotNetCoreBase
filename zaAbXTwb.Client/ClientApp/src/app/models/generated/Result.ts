
export class Result {
	public Message: string ;
	public Ok: boolean ;

	public constructor(
		fields?: Partial<Result>) {

		if (fields) {



			Object.assign(this, fields);
		}
	}
}

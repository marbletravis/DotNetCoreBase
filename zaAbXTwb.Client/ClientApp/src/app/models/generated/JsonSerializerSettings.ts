import { ConstructorHandling } from './ConstructorHandling';
import { DateFormatHandling } from './DateFormatHandling';
import { DateParseHandling } from './DateParseHandling';
import { DateTimeZoneHandling } from './DateTimeZoneHandling';
import { DefaultValueHandling } from './DefaultValueHandling';
import { ErrorEventArgs } from './ErrorEventArgs';
import { FloatFormatHandling } from './FloatFormatHandling';
import { FloatParseHandling } from './FloatParseHandling';
import { FormatterAssemblyStyle } from './FormatterAssemblyStyle';
import { Formatting } from './Formatting';
import { JsonConverter } from './JsonConverter';
import { MetadataPropertyHandling } from './MetadataPropertyHandling';
import { MissingMemberHandling } from './MissingMemberHandling';
import { NullValueHandling } from './NullValueHandling';
import { ObjectCreationHandling } from './ObjectCreationHandling';
import { PreserveReferencesHandling } from './PreserveReferencesHandling';
import { ReferenceLoopHandling } from './ReferenceLoopHandling';
import { SerializationBinder } from './SerializationBinder';
import { StringEscapeHandling } from './StringEscapeHandling';
import { TypeNameAssemblyFormatHandling } from './TypeNameAssemblyFormatHandling';
import { TypeNameHandling } from './TypeNameHandling';

export class JsonSerializerSettings {
	public Binder: SerializationBinder ;
	public CheckAdditionalContent: boolean ;
	public ConstructorHandling: ConstructorHandling ;
	public Context: any ;
	public ContractResolver: any ;
	public Converters: JsonConverter[]  = [];
	public Culture: any ;
	public DateFormatHandling: DateFormatHandling ;
	public DateFormatString: string ;
	public DateParseHandling: DateParseHandling ;
	public DateTimeZoneHandling: DateTimeZoneHandling ;
	public DefaultValueHandling: DefaultValueHandling ;
	public EqualityComparer: any ;
	public Error: any ;
	public FloatFormatHandling: FloatFormatHandling ;
	public FloatParseHandling: FloatParseHandling ;
	public Formatting: Formatting ;
	public MaxDepth: number ;
	public MetadataPropertyHandling: MetadataPropertyHandling ;
	public MissingMemberHandling: MissingMemberHandling ;
	public NullValueHandling: NullValueHandling ;
	public ObjectCreationHandling: ObjectCreationHandling ;
	public PreserveReferencesHandling: PreserveReferencesHandling ;
	public ReferenceLoopHandling: ReferenceLoopHandling ;
	public ReferenceResolver: any ;
	public ReferenceResolverProvider: any ;
	public SerializationBinder: any ;
	public StringEscapeHandling: StringEscapeHandling ;
	public TraceWriter: any ;
	public TypeNameAssemblyFormat: FormatterAssemblyStyle ;
	public TypeNameAssemblyFormatHandling: TypeNameAssemblyFormatHandling ;
	public TypeNameHandling: TypeNameHandling ;

	public constructor(
		fields?: Partial<JsonSerializerSettings>) {

		if (fields) {



			Object.assign(this, fields);
		}
	}
}

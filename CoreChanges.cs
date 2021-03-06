'From Cuis 5.0 of 7 November 2016 [latest update: #2974] on 17 November 2016 at 10:20:33 am'!
!classDefinition: #Dictionary2 category: #'Collections-Unordered'!
Dictionary subclass: #Dictionary2
	instanceVariableNames: ''
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Collections-Unordered'!
!classDefinition: #Set2 category: #'Collections-Unordered'!
Set subclass: #Set2
	instanceVariableNames: ''
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Collections-Unordered'!

!Fraction methodsFor: 'testing' stamp: 'len 10/29/2016 16:05'!
is: aSymbol
	^ aSymbol = #Fraction or: [super is: aSymbol]! !


!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 10/28/2016 20:36'!
cap
	"
	Character cap
	"
	^ self value: 16r98! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 10/28/2016 20:36'!
cup
	"
	Character cup
	"
	^ self value: 16r99! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:40'!
nAryProduct
	"
	Character nAryProduct
	"
	^ self value: 16r8F! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:40'!
nArySum
	"
	Character nArySum
	"
	^ self value: 16r8E! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:39'!
partialDifferential
	"
	Character partialDifferential
	"
	^ self value: 16r8B! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:34'!
pi
	"
	Character pi
	"
	^ self value: 16r82! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:39'!
ring
	"
	Character ring
	"
	^ self value: 16r95! !


!Collection methodsFor: 'enumerating' stamp: 'len 9/1/2016 07:49'!
symmetricDifference: aSet 
	^ (self difference: aSet) � (aSet difference: self)! !

!Collection methodsFor: 'statistics' stamp: 'len 4/29/2016 21:58'!
argmax: aBlock
	"Answer the argument (element of the receiver) that maximizes aBlock."
	^ self detectMax: aBlock! !

!Collection methodsFor: 'statistics' stamp: 'len 6/7/2016 09:38'!
argmin: aBlock
	"Answer the argument (element of the receiver) that minimizes aBlock."
	^ self detectMin: aBlock! !


!SequenceableCollection methodsFor: 'copying' stamp: 'len 3/3/2016 23:07'!
copyWithoutIndex: index 
	| answer |
	answer _ self species new: self size - 1.
	answer replaceFrom: 1 to: index - 1 with: self startingAt: 1.
	answer replaceFrom: index to: answer size with: self startingAt: index + 1.
	^ answer! !

!SequenceableCollection methodsFor: 'copying' stamp: 'len 4/18/2016 22:08'!
shuffledBy: aGenerator
	"To answer a mutable collection when receiver is, for example, an Interval."
	^ (self collect: [ :each | each ]) shuffleBy: aGenerator! !


!String methodsFor: 'testing' stamp: 'len 3/22/2016 21:11'!
isAlphaNumeric
	^ self allSatisfy: [:each| each isAlphaNumeric]! !


!Dictionary2 methodsFor: 'as yet unclassified' stamp: 'len 6/27/2016 22:48'!
scanFor: anObject
	"Scan the key array for the first slot containing either a nil (indicating an empty slot) or an element that matches anObject. Answer the index of that slot or zero if no slot is found. This method will be overridden in various subclasses that have different interpretations for matching elements."
	| element start finish |
	start _ (anObject hash hashMultiply \\ array size) + 1.
	finish _ array size.

	"Search from (hash mod size) to the end."
	start to: finish do:
		[:index | ((element _ array at: index) == nil or: [element key = anObject])
			ifTrue: [^ index ]].

	"Search from 1 to where we started."
	1 to: start-1 do:
		[:index | ((element _ array at: index) == nil or: [element key = anObject])
			ifTrue: [^ index ]].

	^ 0  "No match AND no empty slot"! !


!SystemDictionary methodsFor: 'browsing' stamp: 'len 6/9/2016 23:23'!
browseAllPrimitives
	self browseAllSelect: [:each| each primitive ~= 0 and: [(each primitive between: 256 and: 291) not]]
! !


!Set2 methodsFor: 'as yet unclassified' stamp: 'len 6/10/2016 00:08'!
scanFor1: anObject
	"Scan the key array for the first slot containing either a nil (indicating an empty slot) or an element that matches anObject. Answer the index of that slot or zero if no slot is found. This method will be overridden in various subclasses that have different interpretations for matching elements."
	| element start finish |
	start _ (anObject hash \\ array size) + 1.
	finish _ array size.

	"Search from (hash mod size) to the end."
	start to: finish do:
		[:index | ((element _ array at: index) == nil or: [element = anObject])
			ifTrue: [^ index ]].

	"Search from 1 to where we started."
	1 to: start-1 do:
		[:index | ((element _ array at: index) == nil or: [element = anObject])
			ifTrue: [^ index ]].

	^ 0  "No match AND no empty slot"! !

!Set2 methodsFor: 'as yet unclassified' stamp: 'len 6/10/2016 00:08'!
scanFor2: anObject
	"Scan the key array for the first slot containing either a nil (indicating an empty slot) or an element that matches anObject. Answer the index of that slot or zero if no slot is found. This method will be overridden in various subclasses that have different interpretations for matching elements."
	| finish hash start element |
	finish _ array size.
	finish > 4096
		ifTrue: [hash _ anObject hash * (finish // 4096)]
		ifFalse: [hash _ anObject hash].
	start _ (hash \\ array size) + 1.

	"Search from (hash mod size) to the end."
	start to: finish do:
		[:index | ((element _ array at: index) == nil or: [element = anObject])
			ifTrue: [^ index ]].

	"Search from 1 to where we started."
	1 to: start-1 do:
		[:index | ((element _ array at: index) == nil or: [element = anObject])
			ifTrue: [^ index ]].

	^ 0  "No match AND no empty slot"! !

!Set2 methodsFor: 'as yet unclassified' stamp: 'len 6/27/2016 22:47'!
scanFor3: anObject
	"Scan the key array for the first slot containing either a nil (indicating an empty slot) or an element that matches anObject. Answer the index of that slot or zero if no slot is found. This method will be overridden in various subclasses that have different interpretations for matching elements."
	| finish  start element |
	finish _ array size.
	start _ (anObject hash hashMultiply \\ array size) + 1.
	
	"Search from (hash mod size) to the end."
	start to: finish do:
		[:index | ((element _ array at: index) == nil or: [element = anObject])
			ifTrue: [^ index ]].

	"Search from 1 to where we started."
	1 to: start-1 do:
		[:index | ((element _ array at: index) == nil or: [element = anObject])
			ifTrue: [^ index ]].

	^ 0  "No match AND no empty slot"! !

!Set2 methodsFor: 'as yet unclassified' stamp: 'len 6/27/2016 22:48'!
scanFor: anObject
	"Scan the key array for the first slot containing either a nil (indicating an empty slot) or an element that matches anObject. Answer the index of that slot or zero if no slot is found. This method will be overridden in various subclasses that have different interpretations for matching elements."
	| finish  start element |
	finish _ array size.
	start _ (anObject hash hashMultiply \\ array size) + 1.
	
	"Search from (hash mod size) to the end."
	start to: finish do:
		[:index | ((element _ array at: index) == nil or: [element = anObject])
			ifTrue: [^ index ]].

	"Search from 1 to where we started."
	1 to: start-1 do:
		[:index | ((element _ array at: index) == nil or: [element = anObject])
			ifTrue: [^ index ]].

	^ 0  "No match AND no empty slot"! !


!StrikeFont methodsFor: 'character shapes' stamp: 'len 6/7/2016 06:20'!
takeAllGlyphFor: aCharacter from: sourceCharacter in: aFont
	self takeGlyphFor: aCharacter from: sourceCharacter in: aFont.
	self derivativeFonts do: [:each|
		(aFont derivativeFonts detect: [:one| one emphasis = each emphasis] ifNone: [])
			ifNotNil: [:otherFont| each takeGlyphFor: aCharacter from: sourceCharacter in: otherFont]].
! !


!HaloMorph methodsFor: 'stepping' stamp: 'len 7/25/2016 21:39'!
step
	(target isNil or: [target isInWorld not]) ifTrue: [self delete]! !

!HaloMorph methodsFor: 'stepping' stamp: 'len 7/25/2016 21:41'!
stepTime
	^ 100! !

!HaloMorph methodsFor: 'stepping' stamp: 'len 7/25/2016 21:38'!
wantsSteps
	^ true! !


!BitBltCanvas methodsFor: 'drawing-ovals' stamp: 'len 2/18/2016 06:42'!
fillEllipse: aRectangle color: aColor
	| displayRectangle |
	displayRectangle _ (currentTransformation displayBoundsOfTransformOf: aRectangle) truncated.
	self setPaintColor: aColor.
	port fillOval: displayRectangle! !

!BitBltCanvas methodsFor: 'drawing-ovals' stamp: 'len 2/18/2016 06:43'!
fillEllipse: aRectangle color: aColor borderWidth: borderWidth borderColor: borderColor
	self fillEllipse: (aRectangle insetBy: borderWidth) color: aColor.
	(borderWidth > 0 and: [borderColor isTransparent not])
		ifTrue: [self frameEllipse: aRectangle borderWidth: borderWidth color: borderColor]! !

!BitBltCanvas methodsFor: 'drawing-ovals' stamp: 'len 2/18/2016 06:43'!
frameEllipse: aRectangle borderWidth: borderWidth color: aColor
	| displayRectangle |
	displayRectangle _ (currentTransformation displayBoundsOfTransformOf: aRectangle) truncated.
	self setPaintColor: aColor.
	port frameOval: displayRectangle borderWidth: borderWidth! !


!Theme methodsFor: 'other options' stamp: 'len 6/9/2016 20:57'!
buttonHeight
	"Answer the user's preferred default height for buttons."

	^Preferences standardButtonFont height * 14 // 8! !

!Theme methodsFor: 'private - shout mappings' stamp: 'len 3/5/2016 22:40'!
blockLevelOne

	^ #(
		leftParenthesis1
		rightParenthesis1
		blockStart1
		blockEnd1
	)
! !

!Theme methodsFor: 'private - shout mappings' stamp: 'len 3/5/2016 22:40'!
blockLevelThree

	^ #(
		leftParenthesis3
		rightParenthesis3
		blockStart3
		blockEnd3
	)
! !

!Theme methodsFor: 'private - shout mappings' stamp: 'len 3/5/2016 22:40'!
blockLevelTwo

	^ #(
		leftParenthesis2
		rightParenthesis2
		blockStart2
		blockEnd2
	)
! !

!Theme methodsFor: 'private - shout mappings' stamp: 'len 6/9/2016 04:47'!
errors
	^ #(
		invalid
		excessCode
	)! !


!Workspace methodsFor: 'binding' stamp: 'len 11/23/2015 03:28'!
bindingOf: aString
	mustDeclareVariables ifTrue: [^ nil].
	(bindings includesKey: aString) ifFalse: [
		"aString first isUppercase
			ifTrue: [^nil]
			ifFalse: ["bindings at: aString put: nil]"]".
	^bindings associationAt: aString! !


!Inspector class methodsFor: 'instance creation' stamp: 'len 6/13/2016 00:19'!
openOn: anObject
	| label |
	label _ anObject printString.
	(label includesSubString: anObject class name)
		ifFalse: [label _ anObject class name, ': ', label].
	^ self openOn: anObject withLabel: label! !


!Fraction methodsFor: 'comparing' stamp: 'len 10/29/2016 16:03'!
= aNumber
	self == aNumber ifTrue: [ ^ true ].
	aNumber isFraction
		ifTrue: [numerator = 0 ifTrue: [^ aNumber numerator = 0].
				^ (numerator * aNumber denominator) =
					(aNumber numerator * denominator)
				"Note: used to just compare num and denom,
					but this fails for improper fractions"].
	^ aNumber adaptToFraction: self andSend: #=! !


!Duration methodsFor: 'ansi protocol' stamp: 'len 6/28/2016 09:12'!
hash
	^seconds bitXor: nanos! !


!Character methodsFor: 'testing' stamp: 'len 11/16/2016 08:10'!
isSpecial
	"Answer whether the receiver is one of the special characters that can be used as binary operator."

	^'+-/\*~<>=@,%|&?!!����������׷' includes: self! !


!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:32'!
CC
	"
	Character CC
	"
	^ self value: 16r83! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:32'!
NN
	"
	Character NN
	"
	^ self value: 16r84! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:32'!
PP
	"
	Character PP
	"
	^ self value: 16r85! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:33'!
QQ
	"
	Character QQ
	"
	^ self value: 16r86! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:33'!
RR
	"
	Character RR
	"
	^ self value: 16r87! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:33'!
ZZ
	"
	Character ZZ
	"
	^ self value: 16r88! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:33'!
aleph
	"
	Character aleph
	"
	^ self value: 16r81! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 20:17'!
emptySet
	"
	Character emptySet
	"
	^ self value: 16rD8! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:36'!
exists
	"
	Character exists
	"
	^ self value: 16r8A! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:36'!
forAll
	"
	Character forAll
	"
	^ self value: 16r89! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:37'!
infinity
	"
	Character infinity
	"
	^ self value: 16r80! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:37'!
integral
	"
	Character integral
	"
	^ self value: 16r8C! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:37'!
odot
	"
	Character odot
	"
	^ self value: 16r93! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:38'!
oplus
	"
	Character oplus
	"
	^ self value: 16r90! !

!Character class methodsFor: 'accessing mathematical symbols' stamp: 'len 6/15/2016 23:38'!
otimes
	"
	Character otimes
	"
	^ self value: 16r92! !


!String class methodsFor: 'initialization' stamp: 'len 11/17/2016 10:16:17'!
initialize
	"
	String initialize
	"

	| order newOrder lowercase |

	"Case insensitive compare sorts null, space, digits, letters, all the rest..."
	newOrder _ Array new: 256.
	order _ -1.
	newOrder at: 0+1 put:  (order _ order+1).
	32 to: 64 do: [ :c |
		newOrder at: c + 1 put: (order _ order+1)].
	#(92 124 126 183 215) do: [ :c | "\|~��"
		newOrder at: c + 1 put: (order _ order+1)].
	16r90 to: 16r9F do: [ :i |
		newOrder at: i + 1 put: (order _ order+1)].
	Character uppercaseLowercaseAndUnaccentedLetters do: [ :upperAndLowercase |
		order _ order+1.
		newOrder at: upperAndLowercase first asciiValue + 1 put: order.
		upperAndLowercase size > 1 ifTrue: [
			newOrder at: upperAndLowercase second asciiValue + 1 put: order ]].
	1 to: newOrder size do: [ :i |
		(newOrder at: i) ifNil: [
			newOrder at: i put: (order _ order+1)]].
	CaseInsensitiveOrder _ newOrder asByteArray.
	
	"Case sensitive compare sorts null, space, digits, letters, all the rest..."
	newOrder _ Array new: 256.
	order _ -1.
	newOrder at: 0+1 put:  (order _ order+1).
	28 to: 64 do: [ :c |
		newOrder at: c + 1 put: (order _ order+1)].
	#(92 124 126 183 215) do: [ :c | "\|~��"
		newOrder at: c + 1 put: (order _ order+1)].
	16r90 to: 16r9F do: [ :i |
		newOrder at: i + 1 put: (order _ order+1)].
	Character uppercaseLowercaseAndUnaccentedLetters do: [ :upperAndLowercase |
		upperAndLowercase size > 1 ifTrue: [
			newOrder at: upperAndLowercase first asciiValue + 1 put: (order _ order+1) ]].
	Character uppercaseLowercaseAndUnaccentedLetters do: [ :upperAndLowercase |
		lowercase _ upperAndLowercase size = 1
			ifTrue: [ upperAndLowercase first ]
			ifFalse: [ upperAndLowercase second ].
		newOrder at: lowercase asciiValue + 1 put: (order _ order+1) ].
	1 to: newOrder size do: [ :i |
		(newOrder at: i) ifNil: [
			newOrder at: i put: (order _ order+1)]].
	order = 255 ifFalse: [self error: 'order problem'].
	CaseSensitiveOrder _ newOrder asByteArray.

	"a table for translating to lower case"
	LowercasingTable _ String withAll: (Character characterTable collect: [:c | c asLowercase]).

	"a table for translating to upper case"
	UppercasingTable _ String withAll: (Character characterTable collect: [:c | c asUppercase]).

	"a table for testing tokenish (for fast numArgs)"
	Tokenish _ String withAll: (Character characterTable collect:
									[:c | c tokenish ifTrue: [c] ifFalse: [$~]]).

	"CR and LF--characters that terminate a line"
	CSLineEnders _ CharacterSet new.
	CSLineEnders add: Character cr.
	CSLineEnders add: Character lf.

 	"separators and non-separators"
	CSSeparators _ CharacterSet separators.
	CSNonSeparators _ CSSeparators complement! !


!Dictionary methodsFor: 'printing' stamp: 'len 6/22/2016 16:36'!
printElementsOn: aStream
	aStream nextPut: $(.
	self keysSortedSafely do:
		[:key | aStream print: key; nextPutAll: '->'; print: (self at: key)] separatedBy: [aStream space].
	aStream nextPut: $)! !


!TextAnchor methodsFor: 'copying' stamp: 'len 6/24/2016 22:08'!
postCopy

"	anchoredFormOrMorph _ anchoredFormOrMorph copy"! !


!Form methodsFor: 'fileIn/Out' stamp: 'len 8/1/2016 08:13'!
printOn: aStream
	aStream isText
		ifTrue:
			[aStream withAttribute: (TextAnchor new anchoredFormOrMorph: self) do: [aStream nextPut: $*].
			^ self].
	aStream
		nextPutAll: self class name;
		nextPut: $(; print: width;
		nextPut: $x; print: height;
		nextPut: $x; print: depth;
		nextPut: $)! !


!StrikeFont methodsFor: 'character shapes' stamp: 'len 6/7/2016 06:02'!
takeGlyphFor: aCharacter from: sourceCharacter in: aFont
	"Copy characterForm over the glyph for the argument, character."
	| characterForm r newForm |
	characterForm _ aFont glyphAt: sourceCharacter.
	r _ 0@(0 max: aFont ascent - self ascent) extent: characterForm width @ glyphs height.
	(newForm _ Form extent: characterForm width @ glyphs height depth: glyphs depth)
		fillWhite;
		copyBits: r
		from: characterForm
		at: 0@0
		clippingBox: newForm boundingBox
		rule: Form over.
	self glyphAt: aCharacter put: newForm! !


!StrikeFont class methodsFor: 'instance creation' stamp: 'len 6/15/2016 19:48'!
install: aString
"
StrikeFont install: 'DejaVu'.
StrikeFont buildLargerPunctuation: 'DejaVu'.
Character initialize

StrikeFont install: 'DejaVu Sans Mono'.
StrikeFont buildLargerPunctuation: 'DejaVu Sans Mono'.
Character initialize
"
"
StrikeFont install: 'Inconsolata'
StrikeFont install: '#PilGi'
StrikeFont install: 'Optima'
StrikeFont install: 'Herculanum'
StrikeFont install: 'Papyrus'
StrikeFont install: 'Handwriting - Dakota'
StrikeFont install: 'Times New Roman'
StrikeFont install: 'Apple Chancery'
StrikeFont install: 'Cochin'
StrikeFont install: 'Cracked'
StrikeFont install: 'Zapfino'
StrikeFont install: 'Brush Script MT'
StrikeFont install: 'Chalkboard'
"
	| fontDict |
	fontDict _ Dictionary new.
	"Just try a lot of sizes. Will ignore missing files."
	1 to: 200 do: [ :s |
		(self create: aString size: s bold: true italic: true boldItalic: false) ifNotNil: [ :font |
			fontDict
				at: s
				put: font ]].
	fontDict notEmpty ifTrue: [
		AvailableFonts at: aString put: fontDict ].
"	Preferences restoreDefaultFonts"! !


!MessageSetWindow methodsFor: 'GUI building' stamp: 'len 6/30/2016 07:20'!
buildMorphicWindow
	"Answer a morphic window with the given label that can display the receiver"

	self layoutMorph
		addMorph: self buildMorphicMessageList proportionalHeight: 0.4;
		addAdjusterAndMorph: self buildLowerPanes proportionalHeight: 0.6.
	model changed: #editSelection! !


!DebuggerWindow methodsFor: 'GUI building' stamp: 'len 6/29/2016 21:42'!
buildMorphicWindow
	"Open a full morphic debugger with the given label"

	| upperMorph bottomMorph1 bottomMorph2 bottomMorph3 bottomMorph4 bottomMorph |

	upperMorph _ PluggableListMorph
		model: model 
		listGetter: #contextStackList
		indexGetter: #contextStackIndex
		indexSetter: #toggleContextStackIndex:
		mainView: self
		menuGetter: #contextStackMenu
		keystrokeAction: #contextStackKey:from:.

	bottomMorph1 _ PluggableListMorph
			model: model receiverInspector
			listGetter: #fieldList
			indexGetter: #selectionIndex 
			indexSetter: #toggleIndex:
			mainView: self
			menuGetter: #receiverFieldListMenu
			keystrokeAction: #inspectorKey:from:.
	bottomMorph2 _ TextModelMorph
			textProvider: model receiverInspector
			textGetter: #acceptedContents 
			textSetter: #accept:
			selectionGetter: #contentsSelection.
	bottomMorph3 _ PluggableListMorph
			model: model contextVariablesInspector 
			listGetter: #fieldList
			indexGetter: #selectionIndex 
			indexSetter: #toggleIndex:
			mainView: self
			menuGetter: #contextFieldListMenu
			keystrokeAction: #inspectorKey:from:.
	bottomMorph4 _ TextModelMorph
			textProvider: model contextVariablesInspector
			textGetter: #acceptedContents 
			textSetter: #accept:
			selectionGetter: #contentsSelection.

	bottomMorph _ LayoutMorph newRow.
	bottomMorph
		addMorph: bottomMorph1 proportionalWidth: 0.2;
		addAdjusterAndMorph: bottomMorph2 proportionalWidth: 0.3;
		addAdjusterAndMorph: bottomMorph3 proportionalWidth: 0.2;
		addAdjusterAndMorph: bottomMorph4 proportionalWidth: 0.3.

	self layoutMorph
		addMorph: upperMorph proportionalHeight: 0.3;
		addAdjusterAndMorph: self buildLowerPanes proportionalHeight: 0.5;
		addAdjusterAndMorph: bottomMorph proportionalHeight: 0.2! !


!MenuMorph methodsFor: 'keyboard control' stamp: 'len 6/11/2016 20:40'!
keyboardFocusChange: aBoolean
	"Notify change due to green border for keyboard focus"

	aBoolean ifFalse: [self deleteIfPopUp: nil].
	self redrawNeeded! !


!Theme methodsFor: 'other options' stamp: 'len 6/9/2016 20:57'!
buttonPaneHeight
	"Answer the user's preferred default height for button panes."

	^ self buttonHeight! !

!Theme methodsFor: 'private - shout mappings' stamp: 'len 6/8/2016 01:08'!
firstBlockLevel

	^ #(
		leftParenthesis
		rightParenthesis
"		leftBrace
		rightBrace
"		blockStart
		blockEnd
	)! !

!Theme methodsFor: 'private - shout mappings' stamp: 'len 6/10/2016 05:33'!
generateShoutConfig

	| styles colors |
	
	styles := OrderedCollection new.
	colors := self shout as: Dictionary.

	{
		{self undefined. colors at: #defaults . #normal}.
		{self errors . colors at: #defaults}.
		{self defaults . colors at: #defaults}.
		{self pseudoVariables . colors at: #pseudoVariables . #bold}.
		{self argumentTypes . colors at: #arguments . self italic}.
		{self instVar . colors at: #instVar}.
		{self tempBar . colors at: #tempBar}.
		{self tempVars . colors at: #tempVars . self italic}.
		{self blockTemps . colors at: #blockTemps ifAbsent: [colors at: #tempVars] . self italic}.
		{self messages . colors at: #messages}.
		{self incompleteMessages . colors at: #incompleteMessages . #normal "#underlined"}.
		{self literals . colors at: #literals ifAbsent: [colors at: #pseudoVariables]}.
		{self symbols . colors at: #messages . #bold}.
		{self globals . colors at: #defaults . #bold}.
		{self blockLevelOne . colors at: #blockLevelOne}.
		{self blockLevelTwo . colors at: #blockLevelTwo}.
		{self blockLevelThree . colors at: #blockLevelThree}.
		{self blockLevelFour . colors at: #blockLevelFour}.
		{self blockLevelFive . colors at: #blockLevelFive}.
		{self blockLevelSix . colors at: #blockLevelSix}.
		{self blockLevelSeven . colors at: #blockLevelSeven}.
		{self firstBlockLevel . colors at: #block}.
		{self methodTags . colors at: #methodTags . #bold}.
		{self pattern . nil . #bold}.
		{self ansiAssignment . nil . #bold}.
		{self assignment . nil . #(#bold #withST80Glyphs)}.
		{self return . nil . #(#bold #withST80Glyphs)}.
	} do: [ :style |
		styles addAll:
			(style first
				collect: [ :category | | elements |
					elements _ style asOrderedCollection.
					elements at: 1 put: category.
					Array withAll: elements ])].

	"Miscellaneous remainder after factoring out commonality:"
	styles addAll: {
		{#unfinishedString . colors at: #literals . #normal}.
		{#undefinedIdentifier . colors at: #undefined . #underlined}.
		{#unfinishedComment . colors at: #comment ifAbsent: [colors at: #pseudoVariables] . #normal }.
		{#comment . colors at: #comment ifAbsent: [colors at: #methodTags] . self italic}.
		{#string . colors at: #literals . #normal}.
		{#literal . nil . self italic}.
		{#incompleteIdentifier . colors at: #defaults . #(italic underlined)}.
		{#classVar . colors at: #classVar ifAbsent: [colors at: #tempVars] . #bold}.
	}.

	^ styles! !

!Theme methodsFor: 'private - shout mappings' stamp: 'len 6/8/2016 23:48'!
literals

	^ #(
			character
			integer
			number
			-
"		#'$'"
			blockStart3
			blockEnd3
			leftParenthesis3
			rightParenthesis3
	)! !

!Theme methodsFor: 'private - shout mappings' stamp: 'len 6/10/2016 05:33'!
undefined

	^ #(
		undefinedKeyword
		undefinedBinary
		undefinedUnary
	)! !

!Theme methodsFor: 'shout' stamp: 'len 6/8/2016 00:13'!
shout
	"Color symbols as an association list."
	
	^ {
		#defaults 				-> #black.
		#undefined 				-> #red.
		#comment 				-> #(green muchDarker).
		#methodTags 			-> #(green muchDarker).
		#pseudoVariables 		-> #(red muchDarker).
		#messages 				-> #(blue darker).
		#arguments 				-> #(cyan muchDarker).
		#instVar 					-> #(magenta muchDarker).
		#incompleteMessages -> #(gray veryMuchDarker).
		#blockLevelFour 		-> #(green darker).
		#blockLevelFive 		-> #(orange darker).
		#blockLevelSix 			-> #(magenta darker).
		#blockLevelSeven 		-> #blue.
		#tempBar 				-> #gray.
		#tempVars 				-> #(gray muchDarker).
	}! !

String initialize!

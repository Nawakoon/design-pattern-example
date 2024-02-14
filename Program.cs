// behavioral
using Pattern.ChainOfResponsibility;
using Pattern.Observer;
using Pattern.Command;
using Pattern.Strategy;
using Pattern.Iterator;
using Pattern.Mediator;
using Pattern.Memento;
using Pattern.State;
using Pattern.TemplateMethod;
using Pattern.Visitor;

// creational
using Pattern.AbstractFactory;
using Pattern.Factory;
using Pattern.Builder;
using Pattern.Prototype;
using Pattern.Singleton;

// structural
using Pattern.Adapter;
using Pattern.Bridge;
using Pattern.Composite;
using Pattern.Decorator;
using Pattern.Facade;
using Pattern.Flyweight;
using Pattern.Proxy;

class Program
{
    static void Main(string[] args)
    {
        // Creational
        var runAbstractFactory = false;
        var runFactory = false;
        var runBuilder = false;
        var runPrototype = false;
        var runSingleton = false;
        // var runObjectPool = false;
        // var runLazyInitialization = false;
        // var runDependencyInjection = false;
        // var runServiceLocator = false;
        // var runAmbassador = false;
        // var runBorg = false;
        // var runMultiton = false;

        // Structural
        var runAdapter = false;
        var runBridge = false;
        var runComposite = false;
        var runDecorator = false;
        var runFacade = false;
        var runFlyweight = false;
        var runProxy = false;
        // var runExtensibility = false;
        // var runMarkerInterface = false;
        // var runMixin = false;
        // var runPipeFilter = false;
        // var runOpaquePointer = false;
        // var runModule = false;
        // var runTwin = false;
        // var runDataMapper = false;
        // var runFluentInterface = false;
        // var runCompositeEntity = false;
        // var runFrontController = false;
        // var runRegistry = false;
        // var runBlackboard = false;
        // var runServant = false;
        // var runSpecification = false;
        // var runEntityComponentSystem = false;
        // var runEventQueue = false;
        // var runServiceLayer = false;
        // var runModelViewController = false;
        // var runNakedObjects = false;
        // var runCompositeView = false;
        // var runImmutableObject = false;

        // Behavioral
        var runChainOfResponsibility = false;
        var runCommand = false;
        var runStrategy = false;
        var runObserver = false;
        var runIterator = false;
        var runMediator = false;
        var runMemento = false;
        var runState = false;
        var runTemplateMethod = false;
        var runVisitor = true;
        // var runNullObject = false;
        // var runSpecification = false;
        // var runInterpreter = false;
        // var runCommand = false;
        // var runEventAggregator = false;
        // var runBlackboard = false;
        // var runExternalizeTheStack = false;
        // var runScheduledTask = false;
        // var runSingleServingVisitor = false;
        // var runSubclassSandbox = false;
        // var runDoubleBuffer = false;
        // var runTypeObject = false;
        // var runServant = false;
        // var runSpecification = false;

        // Concurrency
        // var runActiveObject = false;
        // var runBalking = false;
        // var runBarrier = false;
        // var runDoubleCheckedLocking = false;
        // var runGuardedSuspension = false;
        // var runLeaderFollowers = false;
        // var runMonitorObject = false;
        // var runNuclearReaction = false;
        // var runReactor = false;
        // var runReadersWriteLock = false;
        // var runScheduler = false;
        // var runThreadLocal = false;
        // var runThreadPool = false;


        if (runAbstractFactory) {
            AbstractFactory abstractFactory = new AbstractFactory();
            abstractFactory.RunExample();
        }

        if (runFactory) {
            Factory factory = new Factory();
            factory.RunExample();
        }

        if (runBuilder) {
            Builder builder = new Builder();
            builder.RunExample();
        }

        if (runAdapter) {
            Adapter adapter = new Adapter();
            adapter.RunExample();
        }

        if (runStrategy) {
            Strategy strategy = new Strategy();
            strategy.RunExample();
        }

        if (runObserver) {
            Observer observer = new Observer();
            observer.RunExample();
        }

        if (runBridge) {
            Bridge bridge = new Bridge();
            bridge.RunExample();
        }

        if (runCommand) {
            Command command = new Command();
            command.RunExample();
        }

        if (runIterator) {
            Iterator iterator = new Iterator();
            iterator.RunExample();
        }

        if (runPrototype) {
            Prototype prototype = new Prototype();
            prototype.RunExample();
        }

        if (runSingleton) {
            Singleton singleton = new Singleton();
            singleton.RunExample();
        }

        if (runComposite) {
            Composite composite = new Composite();
            composite.RunExample();
        }

        if (runDecorator) {
            Decorator decorator = new Decorator();
            decorator.RunExample();
        }

        if (runFacade) {
            Facade facade = new Facade();
            facade.RunExample();
        }

        if (runFlyweight) {
            Flyweight flyweight = new Flyweight();
            flyweight.RunExample();
        }

        if (runProxy) {
            Proxy proxy = new Proxy();
            proxy.RunExample();
        }

        if (runChainOfResponsibility) {
            CoB chainOfResponsibility = new CoB();
            chainOfResponsibility.RunExample();
        }

        if (runMediator) {
            Mediator mediator = new Mediator();
            mediator.RunExample();
        }

        if (runMemento) {
            Memento memento = new Memento();
            memento.RunExample();
        }

        if (runState) {
            State state = new State();
            state.RunExample();
        }

        if (runTemplateMethod) {
            TemplateMethod templateMethod = new TemplateMethod();
            templateMethod.RunExample();
        }

        if (runVisitor) {
            Visitor visitor = new Visitor();
            visitor.RunExample();
        }
    }
}

/*
Gang of Four
patterns	
Creational	
Abstract factoryBuilderFactory methodPrototypeSingleton
Structural	
AdapterBridgeCompositeDecoratorFacadeFlyweightProxy
Behavioral	
Chain of responsibilityCommandInterpreterIteratorMediatorMementoObserverStateStrategyTemplate methodVisitor
Concurrency
patterns	
Active objectBalkingBinding propertiesDouble-checked lockingEvent-based asynchronousGuarded suspensionJoinLockMonitorProactorReactorRead–write lockSchedulerScheduled-task patternThread poolThread-local storage
Architectural
patterns	
Front controllerInterceptorMVCADRECSn-tierSpecificationPublish–subscribeNaked objectsService locatorActive recordIdentity mapData access objectData transfer objectInversion of controlModel 2Broker
Other
patterns	
BlackboardBusiness delegateComposite entityDependency injectionIntercepting filterLazy loadingMock objectNull objectObject poolServantTwinType tunnelMethod chainingDelegation
*/
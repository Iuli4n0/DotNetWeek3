namespace Week3.Exceptions;
/**
 * Custom exception for middleware verification 
 */
public class NotFoundException(string message) : Exception(message);